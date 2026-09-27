using System;
using Himgiri.Core.Enums;

namespace Himgiri.Core.DTOs;

public record StaffMemberDto(
    Guid Id,
    string Name,
    string Email,
    AdminRole Role,
    string RoleName,
    bool IsActive,
    DateTime? LastLoginAt,
    int AccessFailedCount,
    bool IsLockedOut,
    DateTime? LockoutEnd,
    DateTime CreatedAt
);

public record CreateStaffRequest(
    string Name,
    string Email,
    string Password,
    AdminRole Role
);

public record UpdateStaffRoleRequest(
    AdminRole Role
);

public record UpdateStaffStatusRequest(
    bool IsActive
);

public record ResetStaffPasswordRequest(
    string NewPassword
);
