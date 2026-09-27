using System;
using System.Collections.Generic;
using System.Linq;
using Himgiri.Core.Enums;

namespace Himgiri.Core.Security;

public static class RolePermissionMapping
{
    private static readonly Dictionary<AdminRole, HashSet<string>> RolePermissions = new()
    {
        [AdminRole.SuperAdmin] = new HashSet<string>(Permissions.All, StringComparer.OrdinalIgnoreCase),

        [AdminRole.InventoryManager] = new HashSet<string>(new[]
        {
            Permissions.CatalogView,
            Permissions.CatalogManage,
            Permissions.CatalogEditPricing,
            Permissions.StockView,
            Permissions.StockInward,
            Permissions.StockAdjust,
            Permissions.ReportsInventory
        }, StringComparer.OrdinalIgnoreCase),

        [AdminRole.OrderManager] = new HashSet<string>(new[]
        {
            Permissions.CatalogView,
            Permissions.StockView,
            Permissions.OrdersView,
            Permissions.OrdersFulfill,
            Permissions.OrdersNotes,
            Permissions.OrdersExport
        }, StringComparer.OrdinalIgnoreCase)
    };

    public static IReadOnlyList<string> GetPermissionsForRole(AdminRole role)
    {
        if (RolePermissions.TryGetValue(role, out var permissions))
        {
            return permissions.ToList();
        }

        return Array.Empty<string>();
    }

    public static bool HasPermission(AdminRole role, string permission)
    {
        if (string.IsNullOrWhiteSpace(permission))
        {
            return false;
        }

        if (RolePermissions.TryGetValue(role, out var permissions))
        {
            return permissions.Contains(permission);
        }

        return false;
    }
}
