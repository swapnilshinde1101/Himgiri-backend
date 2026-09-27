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
        // Arrange: OrderManager attempting to refund
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
}
