using System.Security.Claims;
using Himgiri.Core.Enums;

namespace Himgiri.API.Extensions;

public static class AuthExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal user)
    {
        var id = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.TryParse(id, out var guid) ? guid : Guid.Empty;
    }

    public static string GetUserEmail(this ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;
    }

    public static AdminRole? GetUserRole(this ClaimsPrincipal user)
    {
        var role = user.FindFirst(ClaimTypes.Role)?.Value;
        return Enum.TryParse<AdminRole>(role, out var result) ? result : null;
    }

    public static bool IsSuperAdmin(this ClaimsPrincipal user)
    {
        return user.GetUserRole() == AdminRole.SuperAdmin;
    }
}
