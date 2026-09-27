using System;
using System.Linq;
using System.Threading.Tasks;
using Himgiri.Core.DTOs;
using Himgiri.Core.Entities;
using Himgiri.Core.Enums;
using Himgiri.Infrastructure.Data;
using Himgiri.Infrastructure.Services;
using Himgiri.Tests.TestHelpers;
using Microsoft.Data.Sqlite;
using Xunit;

namespace Himgiri.Tests.Unit;

public class StaffServiceTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly HimgiriDbContext _db;
    private readonly StaffService _staffService;

    public StaffServiceTests()
    {
        _connection = SqliteDbContextFactory.CreateOpenConnection();
        _db = SqliteDbContextFactory.CreateContext(_connection);
        _db.Database.EnsureCreated();

        // Clear existing admin users and refresh tokens for test isolation
        _db.RefreshTokens.RemoveRange(_db.RefreshTokens);
        _db.AdminUsers.RemoveRange(_db.AdminUsers);
        _db.SaveChanges();

        _staffService = new StaffService(_db);
    }

    [Fact]
    public async Task CreateStaffAsync_WithValidData_CreatesUserWithHashedPassword()
    {
        // Arrange
        var request = new CreateStaffRequest(
            Name: "John Dispatch",
            Email: "john@himgirigoods.com",
            Password: "SecurePassword123!",
            Role: AdminRole.OrderManager
        );

        // Act
        var result = await _staffService.CreateStaffAsync(request);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(201, result.StatusCode);
        Assert.NotNull(result.Data);
        Assert.Equal("John Dispatch", result.Data.Name);
        Assert.Equal("john@himgirigoods.com", result.Data.Email);
        Assert.Equal(AdminRole.OrderManager, result.Data.Role);
        Assert.True(result.Data.IsActive);

        var savedUser = _db.AdminUsers.FirstOrDefault(u => u.Email == "john@himgirigoods.com");
        Assert.NotNull(savedUser);
        Assert.True(BCrypt.Net.BCrypt.Verify("SecurePassword123!", savedUser.PasswordHash));
    }

    [Fact]
    public async Task CreateStaffAsync_DuplicateEmail_Returns400()
    {
        // Arrange
        var existing = new AdminUser
        {
            Id = Guid.NewGuid(),
            Name = "Existing User",
            Email = "duplicate@himgirigoods.com",
            PasswordHash = "hash",
            Role = AdminRole.OrderManager,
            IsActive = true
        };
        _db.AdminUsers.Add(existing);
        await _db.SaveChangesAsync();

        var request = new CreateStaffRequest(
            Name: "New User",
            Email: "duplicate@himgirigoods.com",
            Password: "Password123!",
            Role: AdminRole.InventoryManager
        );

        // Act
        var result = await _staffService.CreateStaffAsync(request);

        // Assert
        Assert.Equal(400, result.StatusCode);
        Assert.Contains("already exists", result.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task UpdateStaffRoleAsync_PreventsSelfDemotion_WhenUserIsSuperAdmin()
    {
        // Arrange
        var currentAdminId = Guid.NewGuid();
        var admin = new AdminUser
        {
            Id = currentAdminId,
            Name = "Super Admin",
            Email = "super@himgirigoods.com",
            PasswordHash = "hash",
            Role = AdminRole.SuperAdmin,
            IsActive = true
        };
        _db.AdminUsers.Add(admin);
        await _db.SaveChangesAsync();

        var request = new UpdateStaffRoleRequest(AdminRole.InventoryManager);

        // Act
        var result = await _staffService.UpdateStaffRoleAsync(currentAdminId, request, currentUserId: currentAdminId);

        // Assert
        Assert.Equal(400, result.StatusCode);
        Assert.Contains("cannot remove your own SuperAdmin privileges", result.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task UpdateStaffRoleAsync_PreventsDemoting_LastActiveSuperAdmin()
    {
        // Arrange
        var superAdminId = Guid.NewGuid();
        var callerAdminId = Guid.NewGuid();

        var soleSuperAdmin = new AdminUser
        {
            Id = superAdminId,
            Name = "Sole SuperAdmin",
            Email = "sole@himgirigoods.com",
            PasswordHash = "hash",
            Role = AdminRole.SuperAdmin,
            IsActive = true
        };
        _db.AdminUsers.Add(soleSuperAdmin);
        await _db.SaveChangesAsync();

        var request = new UpdateStaffRoleRequest(AdminRole.OrderManager);

        // Act
        var result = await _staffService.UpdateStaffRoleAsync(superAdminId, request, currentUserId: callerAdminId);

        // Assert
        Assert.Equal(400, result.StatusCode);
        Assert.Contains("only active SuperAdmin", result.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task UpdateStaffStatusAsync_PreventsSelfDeactivation()
    {
        // Arrange
        var currentAdminId = Guid.NewGuid();
        var admin = new AdminUser
        {
            Id = currentAdminId,
            Name = "Admin",
            Email = "admin@himgirigoods.com",
            PasswordHash = "hash",
            Role = AdminRole.SuperAdmin,
            IsActive = true
        };
        _db.AdminUsers.Add(admin);
        await _db.SaveChangesAsync();

        var request = new UpdateStaffStatusRequest(IsActive: false);

        // Act
        var result = await _staffService.UpdateStaffStatusAsync(currentAdminId, request, currentUserId: currentAdminId);

        // Assert
        Assert.Equal(400, result.StatusCode);
        Assert.Contains("cannot deactivate your own", result.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task UpdateStaffStatusAsync_DeactivatingUser_RevokesActiveRefreshTokens()
    {
        // Arrange
        var callerAdminId = Guid.NewGuid();
        var targetUserId = Guid.NewGuid();

        var caller = new AdminUser
        {
            Id = callerAdminId,
            Name = "Caller",
            Email = "caller@himgirigoods.com",
            PasswordHash = "hash",
            Role = AdminRole.SuperAdmin,
            IsActive = true
        };

        var target = new AdminUser
        {
            Id = targetUserId,
            Name = "Warehouse Clerk",
            Email = "clerk@himgirigoods.com",
            PasswordHash = "hash",
            Role = AdminRole.InventoryManager,
            IsActive = true
        };

        var token = new RefreshToken
        {
            Id = Guid.NewGuid(),
            UserId = targetUserId,
            TokenHash = "testhash123",
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            RevokedAt = null
        };

        _db.AdminUsers.AddRange(caller, target);
        _db.RefreshTokens.Add(token);
        await _db.SaveChangesAsync();

        var request = new UpdateStaffStatusRequest(IsActive: false);

        // Act
        var result = await _staffService.UpdateStaffStatusAsync(targetUserId, request, currentUserId: callerAdminId);

        // Assert
        Assert.Equal(200, result.StatusCode);
        Assert.False(result.Data!.IsActive);

        var refreshedToken = _db.RefreshTokens.First(rt => rt.Id == token.Id);
        Assert.NotNull(refreshedToken.RevokedAt);
    }

    [Fact]
    public async Task ResetStaffPasswordAsync_UpdatesPasswordAndClearsLockout()
    {
        // Arrange
        var targetUserId = Guid.NewGuid();
        var user = new AdminUser
        {
            Id = targetUserId,
            Name = "Target User",
            Email = "target@himgirigoods.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("OldPassword123!", 11),
            Role = AdminRole.OrderManager,
            IsActive = true,
            AccessFailedCount = 5,
            LockoutEnd = DateTime.UtcNow.AddMinutes(15)
        };
        _db.AdminUsers.Add(user);
        await _db.SaveChangesAsync();

        var request = new ResetStaffPasswordRequest("NewSecurePassword999!");

        // Act
        var result = await _staffService.ResetStaffPasswordAsync(targetUserId, request);

        // Assert
        Assert.Equal(200, result.StatusCode);
        Assert.True(result.Data);

        var updatedUser = _db.AdminUsers.First(u => u.Id == targetUserId);
        Assert.True(BCrypt.Net.BCrypt.Verify("NewSecurePassword999!", updatedUser.PasswordHash));
        Assert.Equal(0, updatedUser.AccessFailedCount);
        Assert.Null(updatedUser.LockoutEnd);
    }

    [Fact]
    public async Task UnlockStaffAccountAsync_ClearsLockout()
    {
        // Arrange
        var targetUserId = Guid.NewGuid();
        var user = new AdminUser
        {
            Id = targetUserId,
            Name = "Locked User",
            Email = "locked@himgirigoods.com",
            PasswordHash = "hash",
            Role = AdminRole.OrderManager,
            IsActive = true,
            AccessFailedCount = 5,
            LockoutEnd = DateTime.UtcNow.AddMinutes(15)
        };
        _db.AdminUsers.Add(user);
        await _db.SaveChangesAsync();

        // Act
        var result = await _staffService.UnlockStaffAccountAsync(targetUserId);

        // Assert
        Assert.Equal(200, result.StatusCode);
        var updated = _db.AdminUsers.First(u => u.Id == targetUserId);
        Assert.Equal(0, updated.AccessFailedCount);
        Assert.Null(updated.LockoutEnd);
    }

    [Fact]
    public async Task DeleteStaffAsync_PreventsSelfDeletion()
    {
        // Arrange
        var adminId = Guid.NewGuid();
        var admin = new AdminUser
        {
            Id = adminId,
            Name = "Admin",
            Email = "admin2@himgirigoods.com",
            PasswordHash = "hash",
            Role = AdminRole.SuperAdmin,
            IsActive = true
        };
        _db.AdminUsers.Add(admin);
        await _db.SaveChangesAsync();

        // Act
        var result = await _staffService.DeleteStaffAsync(adminId, currentUserId: adminId);

        // Assert
        Assert.Equal(400, result.StatusCode);
        Assert.Contains("cannot delete your own", result.Message, StringComparison.OrdinalIgnoreCase);
    }

    public void Dispose()
    {
        _db.Dispose();
        _connection.Dispose();
    }
}
