using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.Core.DTOs;
using Himgiri.Core.Entities;
using Himgiri.Core.Enums;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Himgiri.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Himgiri.Infrastructure.Services;

public class StaffService : IStaffService
{
    private readonly HimgiriDbContext _db;
    private readonly ILogger<StaffService>? _logger;

    public StaffService(HimgiriDbContext db, ILogger<StaffService>? logger = null)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<JsonModel<List<StaffMemberDto>>> GetAllStaffAsync(CancellationToken ct = default)
    {
        var staffList = await _db.AdminUsers
            .Where(u => !u.IsDeleted)
            .OrderBy(u => u.Role)
            .ThenBy(u => u.Name)
            .Select(u => new StaffMemberDto(
                u.Id,
                u.Name,
                u.Email,
                u.Role,
                u.Role.ToString(),
                u.IsActive,
                u.LastLoginAt,
                u.AccessFailedCount,
                u.LockoutEnd.HasValue && u.LockoutEnd.Value > DateTime.UtcNow,
                u.LockoutEnd,
                u.CreatedAt
            ))
            .ToListAsync(ct);

        return JsonModel<List<StaffMemberDto>>.Success(staffList, "Staff members retrieved successfully.");
    }

    public async Task<JsonModel<StaffMemberDto>> GetStaffByIdAsync(Guid id, CancellationToken ct = default)
    {
        var user = await _db.AdminUsers
            .Where(u => u.Id == id && !u.IsDeleted)
            .FirstOrDefaultAsync(ct);

        if (user == null)
        {
            return JsonModel<StaffMemberDto>.Error("Staff member not found.", 404);
        }

        var dto = MapToDto(user);
        return JsonModel<StaffMemberDto>.Success(dto);
    }

    public async Task<JsonModel<StaffMemberDto>> CreateStaffAsync(CreateStaffRequest request, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return JsonModel<StaffMemberDto>.Error("Staff member name is required.", 400);
        }

        if (string.IsNullOrWhiteSpace(request.Email))
        {
            return JsonModel<StaffMemberDto>.Error("Email address is required.", 400);
        }

        var normalizedEmail = request.Email.Trim().ToLowerInvariant();
        if (!normalizedEmail.Contains('@') || !normalizedEmail.Contains('.'))
        {
            return JsonModel<StaffMemberDto>.Error("A valid email address is required.", 400);
        }

        if (string.IsNullOrWhiteSpace(request.Password) || request.Password.Trim().Length < 6)
        {
            return JsonModel<StaffMemberDto>.Error("Password must be at least 6 characters.", 400);
        }

        var emailExists = await _db.AdminUsers
            .AnyAsync(u => u.Email.ToLower() == normalizedEmail && !u.IsDeleted, ct);

        if (emailExists)
        {
            return JsonModel<StaffMemberDto>.Error("A staff member with this email already exists.", 400);
        }

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password.Trim(), 11);

        var newUser = new AdminUser
        {
            Name = request.Name.Trim(),
            Email = normalizedEmail,
            PasswordHash = passwordHash,
            Role = request.Role,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        _db.AdminUsers.Add(newUser);
        await _db.SaveChangesAsync(ct);

        _logger?.LogInformation("New staff user created: {Email} with role {Role}", newUser.Email, newUser.Role);

        return new JsonModel<StaffMemberDto>(MapToDto(newUser), "Staff member created successfully.", 201);
    }

    public async Task<JsonModel<StaffMemberDto>> UpdateStaffRoleAsync(
        Guid targetUserId, 
        UpdateStaffRoleRequest request, 
        Guid currentUserId, 
        CancellationToken ct = default)
    {
        var user = await _db.AdminUsers
            .FirstOrDefaultAsync(u => u.Id == targetUserId && !u.IsDeleted, ct);

        if (user == null)
        {
            return JsonModel<StaffMemberDto>.Error("Staff member not found.", 404);
        }

        // Guard: Prevent self-demotion from SuperAdmin
        if (targetUserId == currentUserId && request.Role != AdminRole.SuperAdmin)
        {
            return JsonModel<StaffMemberDto>.Error("You cannot remove your own SuperAdmin privileges.", 400);
        }

        // Guard: Prevent demoting the only active SuperAdmin
        if (user.Role == AdminRole.SuperAdmin && request.Role != AdminRole.SuperAdmin)
        {
            var activeSuperAdminCount = await _db.AdminUsers
                .CountAsync(u => u.Role == AdminRole.SuperAdmin && u.IsActive && !u.IsDeleted, ct);

            if (activeSuperAdminCount <= 1)
            {
                return JsonModel<StaffMemberDto>.Error("Cannot demote the only active SuperAdmin. Promote another staff member first.", 400);
            }
        }

        user.Role = request.Role;

        // Invalidate active refresh tokens so the user is forced to obtain new token claims
        await RevokeActiveTokensForUserAsync(targetUserId, ct);

        await _db.SaveChangesAsync(ct);

        _logger?.LogInformation("Staff role updated for {Email} to {Role}", user.Email, user.Role);

        return JsonModel<StaffMemberDto>.Success(MapToDto(user), "Staff role updated successfully.");
    }

    public async Task<JsonModel<StaffMemberDto>> UpdateStaffStatusAsync(
        Guid targetUserId, 
        UpdateStaffStatusRequest request, 
        Guid currentUserId, 
        CancellationToken ct = default)
    {
        var user = await _db.AdminUsers
            .FirstOrDefaultAsync(u => u.Id == targetUserId && !u.IsDeleted, ct);

        if (user == null)
        {
            return JsonModel<StaffMemberDto>.Error("Staff member not found.", 404);
        }

        // Guard: Prevent self-deactivation
        if (targetUserId == currentUserId && !request.IsActive)
        {
            return JsonModel<StaffMemberDto>.Error("You cannot deactivate your own administrative account.", 400);
        }

        // Guard: Prevent deactivating the only active SuperAdmin
        if (user.Role == AdminRole.SuperAdmin && !request.IsActive)
        {
            var activeSuperAdminCount = await _db.AdminUsers
                .CountAsync(u => u.Role == AdminRole.SuperAdmin && u.IsActive && !u.IsDeleted, ct);

            if (activeSuperAdminCount <= 1)
            {
                return JsonModel<StaffMemberDto>.Error("Cannot deactivate the only active SuperAdmin. Assign another SuperAdmin first.", 400);
            }
        }

        user.IsActive = request.IsActive;

        // Invalidate sessions immediately if deactivated
        if (!request.IsActive)
        {
            await RevokeActiveTokensForUserAsync(targetUserId, ct);
        }

        await _db.SaveChangesAsync(ct);

        _logger?.LogInformation("Staff status updated for {Email}: IsActive = {IsActive}", user.Email, user.IsActive);

        return JsonModel<StaffMemberDto>.Success(MapToDto(user), $"Staff member {(user.IsActive ? "activated" : "deactivated")} successfully.");
    }

    public async Task<JsonModel<bool>> ResetStaffPasswordAsync(
        Guid targetUserId, 
        ResetStaffPasswordRequest request, 
        CancellationToken ct = default)
    {
        var user = await _db.AdminUsers
            .FirstOrDefaultAsync(u => u.Id == targetUserId && !u.IsDeleted, ct);

        if (user == null)
        {
            return JsonModel<bool>.Error("Staff member not found.", 404);
        }

        if (string.IsNullOrWhiteSpace(request.NewPassword) || request.NewPassword.Trim().Length < 6)
        {
            return JsonModel<bool>.Error("New password must be at least 6 characters.", 400);
        }

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword.Trim(), 11);
        user.AccessFailedCount = 0;
        user.LockoutEnd = null;

        // Invalidate all existing sessions on password reset
        await RevokeActiveTokensForUserAsync(targetUserId, ct);

        await _db.SaveChangesAsync(ct);

        _logger?.LogInformation("Password reset for staff user: {Email}", user.Email);

        return JsonModel<bool>.Success(true, "Password has been reset successfully. Existing sessions have been terminated.");
    }

    public async Task<JsonModel<bool>> UnlockStaffAccountAsync(Guid targetUserId, CancellationToken ct = default)
    {
        var user = await _db.AdminUsers
            .FirstOrDefaultAsync(u => u.Id == targetUserId && !u.IsDeleted, ct);

        if (user == null)
        {
            return JsonModel<bool>.Error("Staff member not found.", 404);
        }

        user.AccessFailedCount = 0;
        user.LockoutEnd = null;

        await _db.SaveChangesAsync(ct);

        _logger?.LogInformation("Account lockout cleared for staff user: {Email}", user.Email);

        return JsonModel<bool>.Success(true, "Account has been unlocked successfully.");
    }

    public async Task<JsonModel<bool>> DeleteStaffAsync(
        Guid targetUserId, 
        Guid currentUserId, 
        CancellationToken ct = default)
    {
        var user = await _db.AdminUsers
            .FirstOrDefaultAsync(u => u.Id == targetUserId && !u.IsDeleted, ct);

        if (user == null)
        {
            return JsonModel<bool>.Error("Staff member not found.", 404);
        }

        // Guard: Prevent self-deletion
        if (targetUserId == currentUserId)
        {
            return JsonModel<bool>.Error("You cannot delete your own administrative account.", 400);
        }

        // Guard: Prevent deleting the only active SuperAdmin
        if (user.Role == AdminRole.SuperAdmin)
        {
            var activeSuperAdminCount = await _db.AdminUsers
                .CountAsync(u => u.Role == AdminRole.SuperAdmin && u.IsActive && !u.IsDeleted, ct);

            if (activeSuperAdminCount <= 1)
            {
                return JsonModel<bool>.Error("Cannot delete the only active SuperAdmin. Assign another SuperAdmin first.", 400);
            }
        }

        user.IsDeleted = true;
        user.IsActive = false;

        await RevokeActiveTokensForUserAsync(targetUserId, ct);

        await _db.SaveChangesAsync(ct);

        _logger?.LogInformation("Staff user deleted (soft): {Email}", user.Email);

        return JsonModel<bool>.Success(true, "Staff member deleted successfully.");
    }

    private async Task RevokeActiveTokensForUserAsync(Guid userId, CancellationToken ct)
    {
        var activeTokens = await _db.RefreshTokens
            .Where(rt => rt.UserId == userId && rt.RevokedAt == null)
            .ToListAsync(ct);

        foreach (var token in activeTokens)
        {
            token.RevokedAt = DateTime.UtcNow;
        }
    }

    private static StaffMemberDto MapToDto(AdminUser u)
    {
        return new StaffMemberDto(
            u.Id,
            u.Name,
            u.Email,
            u.Role,
            u.Role.ToString(),
            u.IsActive,
            u.LastLoginAt,
            u.AccessFailedCount,
            u.LockoutEnd.HasValue && u.LockoutEnd.Value > DateTime.UtcNow,
            u.LockoutEnd,
            u.CreatedAt
        );
    }
}
