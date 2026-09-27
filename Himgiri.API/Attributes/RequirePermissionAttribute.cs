using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Himgiri.Core.Enums;
using Himgiri.Core.Models;
using Himgiri.Core.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Himgiri.API.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class RequirePermissionAttribute : Attribute, IAsyncAuthorizationFilter
{
    private readonly string _permission;

    public RequirePermissionAttribute(string permission)
    {
        _permission = permission;
    }

    public Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        if (user?.Identity?.IsAuthenticated != true)
        {
            context.Result = new UnauthorizedObjectResult(JsonModel<object>.Error("Unauthorized: Authentication required.", 401));
            return Task.CompletedTask;
        }

        // 1. Direct permission claim check in JWT
        bool hasPermission = user.Claims.Any(c => 
            (c.Type == "permission" || c.Type == "permissions") && 
            string.Equals(c.Value, _permission, StringComparison.OrdinalIgnoreCase));

        // 2. Fallback to Role Permission Mapping
        if (!hasPermission)
        {
            var roleClaim = user.FindFirst(ClaimTypes.Role)?.Value ?? user.FindFirst("role")?.Value;
            if (Enum.TryParse<AdminRole>(roleClaim, true, out var role))
            {
                hasPermission = RolePermissionMapping.HasPermission(role, _permission);
            }
        }

        if (!hasPermission)
        {
            context.Result = new ObjectResult(JsonModel<object>.Error($"Forbidden: You do not have permission '{_permission}' to perform this action.", 403))
            {
                StatusCode = StatusCodes.Status403Forbidden
            };
        }

        return Task.CompletedTask;
    }
}
