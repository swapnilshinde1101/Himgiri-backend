using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Himgiri.API.Attributes;
using Himgiri.Core.Enums;
using Himgiri.Core.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Xunit;

namespace Himgiri.Tests.Unit;

public class PermissionTests
{
    [Fact]
    public void RolePermissionMapping_SuperAdmin_HasAllPermissions()
    {
        var permissions = RolePermissionMapping.GetPermissionsForRole(AdminRole.SuperAdmin);

        Assert.Equal(Permissions.All.Count, permissions.Count);
        Assert.True(RolePermissionMapping.HasPermission(AdminRole.SuperAdmin, Permissions.OrdersRefund));
        Assert.True(RolePermissionMapping.HasPermission(AdminRole.SuperAdmin, Permissions.StaffManage));
        Assert.True(RolePermissionMapping.HasPermission(AdminRole.SuperAdmin, Permissions.StockAdjust));
    }

    [Fact]
    public void RolePermissionMapping_InventoryManager_CannotRefundOrManageStaff()
    {
        Assert.True(RolePermissionMapping.HasPermission(AdminRole.InventoryManager, Permissions.CatalogManage));
        Assert.True(RolePermissionMapping.HasPermission(AdminRole.InventoryManager, Permissions.StockInward));
        Assert.True(RolePermissionMapping.HasPermission(AdminRole.InventoryManager, Permissions.ReportsInventory));

        Assert.False(RolePermissionMapping.HasPermission(AdminRole.InventoryManager, Permissions.OrdersRefund));
        Assert.False(RolePermissionMapping.HasPermission(AdminRole.InventoryManager, Permissions.StaffManage));
        Assert.False(RolePermissionMapping.HasPermission(AdminRole.InventoryManager, Permissions.ReportsAccounts));
    }

    [Fact]
    public void RolePermissionMapping_OrderManager_CannotAdjustStockOrRefund()
    {
        Assert.True(RolePermissionMapping.HasPermission(AdminRole.OrderManager, Permissions.OrdersView));
        Assert.True(RolePermissionMapping.HasPermission(AdminRole.OrderManager, Permissions.OrdersFulfill));
        Assert.True(RolePermissionMapping.HasPermission(AdminRole.OrderManager, Permissions.OrdersExport));

        Assert.False(RolePermissionMapping.HasPermission(AdminRole.OrderManager, Permissions.StockAdjust));
        Assert.False(RolePermissionMapping.HasPermission(AdminRole.OrderManager, Permissions.OrdersRefund));
        Assert.False(RolePermissionMapping.HasPermission(AdminRole.OrderManager, Permissions.CatalogManage));
        Assert.False(RolePermissionMapping.HasPermission(AdminRole.OrderManager, Permissions.StaffManage));
    }

    [Fact]
    public async Task RequirePermissionAttribute_WhenUserHasPermission_PassesAuthorization()
    {
        // Arrange
        var attribute = new RequirePermissionAttribute(Permissions.OrdersFulfill);
        var httpContext = new DefaultHttpContext();
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, "OrderManager"),
            new Claim("permission", Permissions.OrdersFulfill)
        };
        httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(claims, "TestAuth"));

        var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
        var filterContext = new AuthorizationFilterContext(actionContext, new List<IFilterMetadata>());

        // Act
        await attribute.OnAuthorizationAsync(filterContext);

        // Assert
        Assert.Null(filterContext.Result);
    }

    [Fact]
    public async Task RequirePermissionAttribute_WhenUserLacksPermission_Returns403Forbidden()
    {
        // Arrange: legacy-style token with no permission claims at all — falls back to role defaults.
        // OrderManager's role default does not include OrdersRefund.
        var attribute = new RequirePermissionAttribute(Permissions.OrdersRefund);
        var httpContext = new DefaultHttpContext();
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, "OrderManager")
        };
        httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(claims, "TestAuth"));

        var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
        var filterContext = new AuthorizationFilterContext(actionContext, new List<IFilterMetadata>());

        // Act
        await attribute.OnAuthorizationAsync(filterContext);

        // Assert
        Assert.NotNull(filterContext.Result);
        var objectResult = Assert.IsType<ObjectResult>(filterContext.Result);
        Assert.Equal(403, objectResult.StatusCode);
    }

    [Fact]
    public async Task RequirePermissionAttribute_NoPermissionClaimsAtAll_FallsBackToRoleDefault_Passes()
    {
        // A degenerate/legacy token with a role claim but zero permission claims should still work —
        // OrderManager's role default DOES include OrdersFulfill.
        var attribute = new RequirePermissionAttribute(Permissions.OrdersFulfill);
        var httpContext = new DefaultHttpContext();
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, "OrderManager")
        };
        httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(claims, "TestAuth"));

        var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
        var filterContext = new AuthorizationFilterContext(actionContext, new List<IFilterMetadata>());

        await attribute.OnAuthorizationAsync(filterContext);

        Assert.Null(filterContext.Result);
    }

    [Fact]
    public async Task RequirePermissionAttribute_CustomRestrictedBelowRoleDefault_Returns403Forbidden()
    {
        // Regression test: OrderManager's role default includes OrdersFulfill, but this token's
        // explicit permission claims (simulating a CustomPermissions-narrowed staff account) deliberately
        // omit it. The attribute must trust the token's claims and NOT silently re-grant the role
        // default — that would defeat the whole point of restricting a staff member below their role.
        var attribute = new RequirePermissionAttribute(Permissions.OrdersFulfill);
        var httpContext = new DefaultHttpContext();
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, "OrderManager"),
            new Claim("permission", Permissions.OrdersView) // narrowed: view-only, no fulfill
        };
        httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(claims, "TestAuth"));

        var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
        var filterContext = new AuthorizationFilterContext(actionContext, new List<IFilterMetadata>());

        await attribute.OnAuthorizationAsync(filterContext);

        Assert.NotNull(filterContext.Result);
        var objectResult = Assert.IsType<ObjectResult>(filterContext.Result);
        Assert.Equal(403, objectResult.StatusCode);
    }
}
