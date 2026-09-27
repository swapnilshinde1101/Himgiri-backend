namespace Himgiri.Core.Security;

public static class Permissions
{
    // ── Catalog & Items ──
    public const string CatalogView = "catalog:view";
    public const string CatalogManage = "catalog:manage";
    public const string CatalogEditPricing = "catalog:edit_pricing";

    // ── Inventory & Stock ──
    public const string StockView = "stock:view";
    public const string StockInward = "stock:inward";
    public const string StockAdjust = "stock:adjust";

    // ── Orders & Fulfillment ──
    public const string OrdersView = "orders:view";
    public const string OrdersFulfill = "orders:fulfill";
    public const string OrdersNotes = "orders:notes";
    public const string OrdersRefund = "orders:refund";
    public const string OrdersExport = "orders:export";

    // ── Reports & Analytics ──
    public const string ReportsAccounts = "reports:accounts";
    public const string ReportsInventory = "reports:inventory";
    public const string ReportsStaffAudit = "reports:staff_audit";

    // ── System & Administration ──
    public const string SettingsView = "settings:view";
    public const string SettingsManage = "settings:manage";
    public const string StaffManage = "staff:manage";

    public static readonly IReadOnlyList<string> All = new[]
    {
        CatalogView,
        CatalogManage,
        CatalogEditPricing,
        StockView,
        StockInward,
        StockAdjust,
        OrdersView,
        OrdersFulfill,
        OrdersNotes,
        OrdersRefund,
        OrdersExport,
        ReportsAccounts,
        ReportsInventory,
        ReportsStaffAudit,
        SettingsView,
        SettingsManage,
        StaffManage
    };
}
