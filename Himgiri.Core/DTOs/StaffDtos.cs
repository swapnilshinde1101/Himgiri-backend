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
    DateTime CreatedAt,
    System.Collections.Generic.IReadOnlyList<string>? CustomPermissions = null,
    System.Collections.Generic.IReadOnlyList<string>? EffectivePermissions = null
);

public record CreateStaffRequest(
    string Name,
    string Email,
    string Password,
    AdminRole Role,
    System.Collections.Generic.List<string>? CustomPermissions = null
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

public record UpdateStaffPermissionsRequest(
    System.Collections.Generic.List<string>? Permissions
);
