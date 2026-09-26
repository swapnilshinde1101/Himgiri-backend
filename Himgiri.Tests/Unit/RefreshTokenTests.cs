using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;
using Himgiri.Core.Entities;
using Himgiri.Core.Enums;
using Himgiri.Infrastructure.Data;
using Himgiri.Infrastructure.Services;
using Himgiri.Tests.TestHelpers;

namespace Himgiri.Tests.Unit;

public class RefreshTokenTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly HimgiriDbContext _db;
    private readonly AuthService _authService;

    public RefreshTokenTests()
    {
        _connection = SqliteDbContextFactory.CreateOpenConnection();
        _db = SqliteDbContextFactory.CreateContext(_connection);
        _db.Database.EnsureCreated();

        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Jwt:Key"] = "unit-test-secret-key-must-be-at-least-32-chars"
            })
            .Build();

        _authService = new AuthService(_db, config);
    }

    private async Task<AdminUser> SeedUserAsync(bool isActive = true)
    {
        var user = new AdminUser
        {
            Id = Guid.NewGuid(),
            Name = "QA Refresh Test Admin",
            Email = $"qa.refresh.{Guid.NewGuid():N}@himgiritest.local",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("CorrectPass1!"),
            Role = AdminRole.OrderManager,
            IsActive = isActive
        };
        _db.AdminUsers.Add(user);
        await _db.SaveChangesAsync();
        return user;
    }

    private async Task<string> LoginAndGetRefreshTokenAsync(AdminUser user)
    {
        var result = await _authService.LoginAsync(
            new Himgiri.Core.DTOs.LoginRequest(user.Email, "CorrectPass1!"));
        Assert.NotNull(result);
        return result!.RefreshToken;
    }

    [Fact]
    public async Task LoginAsync_Success_AlsoIssuesAWorkingRefreshToken()
    {
        var user = await SeedUserAsync();

        var result = await _authService.LoginAsync(
            new Himgiri.Core.DTOs.LoginRequest(user.Email, "CorrectPass1!"));

        Assert.NotNull(result);
        Assert.False(string.IsNullOrWhiteSpace(result!.RefreshToken));

        var refreshed = await _authService.RefreshAsync(result.RefreshToken);
        Assert.NotNull(refreshed);
    }

    [Fact]
    public async Task RefreshAsync_ValidToken_RotatesAndRevokesOldOne()
    {
        var user = await SeedUserAsync();
        var originalToken = await LoginAndGetRefreshTokenAsync(user);

        var result = await _authService.RefreshAsync(originalToken);

        Assert.NotNull(result);
        Assert.False(string.IsNullOrWhiteSpace(result!.Token));
        Assert.NotEqual(originalToken, result.RefreshToken);

        // The old token must now be dead — using it again should fail.
        var reuseAttempt = await _authService.RefreshAsync(originalToken);
        Assert.Null(reuseAttempt);
    }

    [Fact]
    public async Task RefreshAsync_UnknownToken_ReturnsNull()
    {
        var result = await _authService.RefreshAsync("this-token-was-never-issued");

        Assert.Null(result);
    }

    [Fact]
    public async Task RefreshAsync_EmptyOrNullToken_ReturnsNullWithoutThrowing()
    {
        Assert.Null(await _authService.RefreshAsync(""));
        Assert.Null(await _authService.RefreshAsync(null!));
    }

    [Fact]
    public async Task RefreshAsync_ExpiredToken_ReturnsNull()
    {
        var user = await SeedUserAsync();
        var token = await LoginAndGetRefreshTokenAsync(user);

        var row = await _db.RefreshTokens.FirstAsync(rt => rt.UserId == user.Id);
        row.ExpiresAt = DateTime.UtcNow.AddDays(-1);
        await _db.SaveChangesAsync();

        var result = await _authService.RefreshAsync(token);

        Assert.Null(result);
    }

    [Fact]
    public async Task RefreshAsync_ReusedRevokedToken_RevokesAllActiveTokensForThatUser()
    {
        // Regression test: reuse of an already-rotated refresh token is a signal of theft.
        // A legitimate client only ever presents the newest token in the chain, so if the
        // old one comes back, every active token for that user must die — including any
        // token issued by the rotation that made the reused one stale in the first place.
        var user = await SeedUserAsync();
        var originalToken = await LoginAndGetRefreshTokenAsync(user);

        var firstRotation = await _authService.RefreshAsync(originalToken);
        Assert.NotNull(firstRotation);

        // Attacker replays the now-revoked original token.
        var reuseResult = await _authService.RefreshAsync(originalToken);
        Assert.Null(reuseResult);

        // The legitimate token from the first rotation must also be dead now.
        var legitimateFollowUp = await _authService.RefreshAsync(firstRotation!.RefreshToken);
        Assert.Null(legitimateFollowUp);
    }

    [Fact]
    public async Task RefreshAsync_DeactivatedAccount_RevokesTokenAndReturnsNull()
    {
        // Regression test: this is the actual point that closes the old "no revocation"
        // gap — an access token used to stay valid for up to 8 hours after an admin was
        // deactivated. Now the very next refresh attempt fails outright.
        var user = await SeedUserAsync();
        var token = await LoginAndGetRefreshTokenAsync(user);

        user.IsActive = false;
        await _db.SaveChangesAsync();

        var result = await _authService.RefreshAsync(token);

        Assert.Null(result);

        var row = await _db.RefreshTokens.FirstAsync(rt => rt.UserId == user.Id);
        Assert.NotNull(row.RevokedAt);
    }

    [Fact]
    public async Task RevokeRefreshTokenAsync_ValidToken_MarksItRevoked()
    {
        var user = await SeedUserAsync();
        var token = await LoginAndGetRefreshTokenAsync(user);

        await _authService.RevokeRefreshTokenAsync(token);

        var result = await _authService.RefreshAsync(token);
        Assert.Null(result);
    }

    [Fact]
    public async Task RevokeRefreshTokenAsync_UnknownToken_DoesNotThrow()
    {
        // Logout should be forgiving — an already-expired/unknown token is not an error.
        await _authService.RevokeRefreshTokenAsync("never-issued-token");
    }

    public void Dispose()
    {
        _db.Dispose();
        _connection.Dispose();
    }
}
