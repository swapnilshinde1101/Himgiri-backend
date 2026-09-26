using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Himgiri.Core.DTOs;
using Himgiri.Core.Entities;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Himgiri.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly HimgiriDbContext _db;
    private readonly IConfiguration _config;

    // Short-lived access token: even a stolen token is only useful for a few minutes,
    // and a deactivated account is locked out of getting a new one on the very next
    // refresh instead of staying valid for hours.
    private static readonly TimeSpan AccessTokenLifetime = TimeSpan.FromMinutes(15);
    private static readonly TimeSpan RefreshTokenLifetime = TimeSpan.FromDays(7);

    public AuthService(HimgiriDbContext db, IConfiguration config)
    {
        _db = db;
        _config = config;
    }

    // Dummy hash used to equalize execution time when an email does not exist (prevents timing attacks)
    private const string DummyPasswordHash = "$2a$11$e87.tZtKj7F2C0vVvFhT7.vV9vB/lC1fMZe6TjJ3O0M9jB3mD8eK6";

    public async Task<LoginResponse?> LoginAsync(LoginRequest request, CancellationToken ct = default)
    {
        var email = request.Email.ToLower().Trim();

        var user = await _db.AdminUsers
            .FirstOrDefaultAsync(u => u.Email.ToLower() == email && !u.IsDeleted, ct);

        if (user is null)
        {
            // Defend against timing attacks: run dummy verification so response times match valid users
            BCrypt.Net.BCrypt.Verify(request.Password, DummyPasswordHash);
            return null;
        }

        if (!user.IsActive)
        {
            throw new UnauthorizedAccessException("Account is disabled. Please contact the administrator.");
        }

        // 1. Check if account is locked out
        if (user.LockoutEnd.HasValue && user.LockoutEnd > DateTime.UtcNow)
            throw new UnauthorizedAccessException($"Account is locked until {user.LockoutEnd.Value.ToLocalTime():HH:mm}. Too many failed attempts.");

        // 2. Verify BCrypt password hash
        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

        if (!isPasswordValid)
        {
            // Increment failed attempts
            user.AccessFailedCount++;

            // Lock out after 5 failed attempts for 15 minutes
            if (user.AccessFailedCount >= 5)
            {
                user.LockoutEnd = DateTime.UtcNow.AddMinutes(15);
                user.AccessFailedCount = 0; // Reset count for next cycle
            }

            await _db.SaveChangesAsync(ct);
            return null;
        }

        // 3. Reset failed attempts on successful login
        user.AccessFailedCount = 0;
        user.LockoutEnd = null;
        user.LastLoginAt = DateTime.UtcNow;

        var expiry = DateTime.UtcNow.Add(AccessTokenLifetime);
        var token = GenerateToken(user);
        var (refreshToken, _) = IssueRefreshToken(user.Id);

        await _db.SaveChangesAsync(ct);

        return new LoginResponse(token, refreshToken, user.Name, user.Email, user.Role, expiry);
    }

    public async Task<RefreshTokenResponse?> RefreshAsync(string refreshToken, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(refreshToken))
        {
            return null;
        }

        var tokenHash = HashToken(refreshToken);
        var existing = await _db.RefreshTokens
            .Include(rt => rt.User)
            .FirstOrDefaultAsync(rt => rt.TokenHash == tokenHash, ct);

        if (existing is null)
        {
            return null;
        }

        if (existing.RevokedAt != null)
        {
            // Reuse of an already-rotated token is a strong signal the token was stolen
            // (a legitimate client only ever presents the latest one in the chain) — revoke
            // every active token for this user so the attacker's session dies too.
            await RevokeAllRefreshTokensForUserAsync(existing.UserId, ct);
            return null;
        }

        if (existing.ExpiresAt <= DateTime.UtcNow)
        {
            return null;
        }

        var user = existing.User;
        if (user is null || user.IsDeleted || !user.IsActive ||
            (user.LockoutEnd.HasValue && user.LockoutEnd > DateTime.UtcNow))
        {
            // Account was deactivated/deleted/locked since this refresh token was issued —
            // this is the actual point that closes the old "revocation" gap: instead of the
            // access token staying valid for up to 8 hours regardless, the very next refresh
            // (at most 15 minutes later) fails outright.
            existing.RevokedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync(ct);
            return null;
        }

        // Rotate: issue a new pair, revoke the old one and link it to its replacement.
        var (newRefreshToken, newRefreshTokenId) = IssueRefreshToken(user.Id);

        existing.RevokedAt = DateTime.UtcNow;
        existing.ReplacedByTokenId = newRefreshTokenId;

        var newAccessToken = GenerateToken(user);
        var newExpiry = DateTime.UtcNow.Add(AccessTokenLifetime);

        await _db.SaveChangesAsync(ct);

        return new RefreshTokenResponse(newAccessToken, newRefreshToken, newExpiry);
    }

    public async Task RevokeRefreshTokenAsync(string refreshToken, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(refreshToken))
        {
            return;
        }

        var tokenHash = HashToken(refreshToken);
        var existing = await _db.RefreshTokens.FirstOrDefaultAsync(rt => rt.TokenHash == tokenHash, ct);
        if (existing != null && existing.RevokedAt == null)
        {
            existing.RevokedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync(ct);
        }
    }

    private async Task RevokeAllRefreshTokensForUserAsync(Guid userId, CancellationToken ct)
    {
        var activeTokens = await _db.RefreshTokens
            .Where(rt => rt.UserId == userId && rt.RevokedAt == null)
            .ToListAsync(ct);

        foreach (var token in activeTokens)
        {
            token.RevokedAt = DateTime.UtcNow;
        }

        await _db.SaveChangesAsync(ct);
    }

    // Not saved here — the caller's own SaveChangesAsync persists this alongside whatever
    // else it's doing in the same unit of work (e.g. revoking the token being rotated out).
    // BaseEntity.Id is generated client-side at construction, so the Id is known immediately
    // without a round-trip to the database.
    private (string RawToken, Guid TokenId) IssueRefreshToken(Guid userId)
    {
        var rawToken = Convert.ToHexString(RandomNumberGenerator.GetBytes(32));

        var entity = new RefreshToken
        {
            UserId = userId,
            TokenHash = HashToken(rawToken),
            ExpiresAt = DateTime.UtcNow.Add(RefreshTokenLifetime)
        };

        _db.RefreshTokens.Add(entity);

        return (rawToken, entity.Id);
    }

    private static string HashToken(string rawToken)
    {
        return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(rawToken)));
    }

    public string GenerateToken(AdminUser user)
    {
        var jwtKey = _config["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not configured");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim("role", user.Role.ToString()) // extra for easy frontend reading
        };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.Add(AccessTokenLifetime),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
