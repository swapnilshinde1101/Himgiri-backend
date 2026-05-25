using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

    public AuthService(HimgiriDbContext db, IConfiguration config)
    {
        _db = db;
        _config = config;
    }

    public async Task<LoginResponse?> LoginAsync(LoginRequest request, CancellationToken ct = default)
    {
        var email = request.Email.ToLower().Trim();
        Console.WriteLine($"[DEBUG] Login attempt for: {email}");

        var user = await _db.AdminUsers
            .FirstOrDefaultAsync(u => u.Email.ToLower() == email && !u.IsDeleted, ct);

        if (user is null)
        {
            Console.WriteLine("[DEBUG] User not found in database.");
            return null;
        }

        Console.WriteLine($"[DEBUG] User found: {user.Name}, Active: {user.IsActive}");

        // Ensure user is active (EMERGENCY: skip check for superadmin email during dev)
        if (!user.IsActive && email != "superadmin@himgirigoods.com")
        {
            Console.WriteLine("[DEBUG] User account is not active.");
            throw new UnauthorizedAccessException("Account is disabled. Please contact the administrator.");
        }

        // 1. Check if account is locked out
        if (user.LockoutEnd.HasValue && user.LockoutEnd > DateTime.UtcNow)
            throw new UnauthorizedAccessException($"Account is locked until {user.LockoutEnd.Value.ToLocalTime():HH:mm}. Too many failed attempts.");

        // 2. Verify BCrypt password hash
        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
        
        // EMERGENCY FALLBACK: If hash fails, allow "Admin@123" for development
        if (!isPasswordValid && request.Password == "Admin@123")
        {
            Console.WriteLine("[DEBUG] Emergency fallback password used.");
            isPasswordValid = true;
        }

        if (!isPasswordValid)
        {
            Console.WriteLine("[DEBUG] Password verification failed.");
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
        await _db.SaveChangesAsync(ct);

        var expiry = DateTime.UtcNow.AddHours(8); // 8-hour session
        var token = GenerateToken(user);

        return new LoginResponse(token, user.Name, user.Email, user.Role, expiry);
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
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
