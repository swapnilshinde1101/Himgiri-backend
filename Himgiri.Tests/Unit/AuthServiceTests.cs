using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;
using Himgiri.Core.DTOs;
using Himgiri.Core.Entities;
using Himgiri.Core.Enums;
using Himgiri.Infrastructure.Data;
using Himgiri.Infrastructure.Services;
using Himgiri.Tests.TestHelpers;

namespace Himgiri.Tests.Unit;

public class AuthServiceTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly HimgiriDbContext _db;
    private readonly AuthService _authService;

    public AuthServiceTests()
    {
        _connection = SqliteDbContextFactory.CreateOpenConnection();
        _db = SqliteDbContextFactory.CreateContext(_connection);
        _db.Database.EnsureCreated();

        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Jwt:Key"] = "unit-test-secret-key-must-be-at-least-32-chars",
                ["Jwt:Issuer"] = "himgiri-test",
                ["Jwt:Audience"] = "himgiri-test"
            })
            .Build();

        _authService = new AuthService(_db, config);
    }

    private async Task<AdminUser> SeedUserAsync(string email, string password, bool isActive = true)
    {
        var user = new AdminUser
        {
            Id = Guid.NewGuid(),
            Name = "QA Test Admin",
            Email = email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
            Role = AdminRole.OrderManager,
            IsActive = isActive
        };
        _db.AdminUsers.Add(user);
        await _db.SaveChangesAsync();
        return user;
    }

    [Fact]
    public async Task LoginAsync_UnknownEmail_ReturnsNull()
    {
        var result = await _authService.LoginAsync(new LoginRequest("nobody@himgiritest.local", "whatever"));

        Assert.Null(result);
    }

    [Fact]
    public async Task LoginAsync_CorrectPassword_ReturnsTokenAndResetsFailedCount()
    {
        var user = await SeedUserAsync("qa.correct@himgiritest.local", "CorrectPass1!");
        user.AccessFailedCount = 3;
        await _db.SaveChangesAsync();

        var result = await _authService.LoginAsync(new LoginRequest("qa.correct@himgiritest.local", "CorrectPass1!"));

        Assert.NotNull(result);
        Assert.False(string.IsNullOrWhiteSpace(result!.Token));

        var reloaded = await _db.AdminUsers.FirstAsync(u => u.Id == user.Id);
        Assert.Equal(0, reloaded.AccessFailedCount);
    }

    [Fact]
    public async Task LoginAsync_WrongPassword_ReturnsNullAndIncrementsFailedCount()
    {
        var user = await SeedUserAsync("qa.wrongpass@himgiritest.local", "CorrectPass1!");

        var result = await _authService.LoginAsync(new LoginRequest("qa.wrongpass@himgiritest.local", "WrongPassword!"));

        Assert.Null(result);
        var reloaded = await _db.AdminUsers.FirstAsync(u => u.Id == user.Id);
        Assert.Equal(1, reloaded.AccessFailedCount);
    }

    [Fact]
    public async Task LoginAsync_HardcodedDevPassword_IsNoLongerAccepted()
    {
        // Regression test: a removed "#if DEBUG" fallback used to let ANY account log in
        // with the literal password "Admin@123" regardless of its real hash.
        await SeedUserAsync("qa.backdoor@himgiritest.local", "SomeOtherRealPassword!");

        var result = await _authService.LoginAsync(new LoginRequest("qa.backdoor@himgiritest.local", "Admin@123"));

        Assert.Null(result);
    }

    [Fact]
    public async Task LoginAsync_FifthFailedAttempt_LocksAccountFor15Minutes()
    {
        var user = await SeedUserAsync("qa.lockout@himgiritest.local", "CorrectPass1!");

        for (int i = 0; i < 5; i++)
        {
            await _authService.LoginAsync(new LoginRequest("qa.lockout@himgiritest.local", "WrongPassword!"));
        }

        var reloaded = await _db.AdminUsers.FirstAsync(u => u.Id == user.Id);
        Assert.Equal(0, reloaded.AccessFailedCount); // reset once lockout triggers
        Assert.NotNull(reloaded.LockoutEnd);
        Assert.True(reloaded.LockoutEnd > DateTime.UtcNow);
    }

    [Fact]
    public async Task LoginAsync_LockedOutAccount_ThrowsEvenWithCorrectPassword()
    {
        var user = await SeedUserAsync("qa.locked@himgiritest.local", "CorrectPass1!");
        user.LockoutEnd = DateTime.UtcNow.AddMinutes(10);
        await _db.SaveChangesAsync();

        await Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
            _authService.LoginAsync(new LoginRequest("qa.locked@himgiritest.local", "CorrectPass1!")));
    }

    [Fact]
    public async Task LoginAsync_InactiveSuperAdmin_NoLongerBypassesActiveCheck()
    {
        // Regression test: a removed bypass let the superadmin email skip the IsActive
        // check entirely ("EMERGENCY" comment). The seeded superadmin's real password
        // is "Admin@123" (see HimgiriDbContext seed data) — using it here proves this
        // is a genuine credential check, not a re-test of the removed dev backdoor.
        var superAdmin = await _db.AdminUsers.FirstAsync(u => u.Email == "superadmin@himgirigoods.com");
        superAdmin.IsActive = false;
        await _db.SaveChangesAsync();

        await Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
            _authService.LoginAsync(new LoginRequest("superadmin@himgirigoods.com", "Admin@123")));
    }

    public void Dispose()
    {
        _db.Dispose();
        _connection.Dispose();
    }
}
