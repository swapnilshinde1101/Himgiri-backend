namespace Himgiri.Core.Enums;

public enum StorageStatus
{
    InStock,    // Available for home delivery immediately
    PreOrder    // Under printing — delivered to classroom in June 2026
}

public enum OrderStatus
{
    Pending,
    Confirmed,
    Packed,
    Dispatched,
    Delivered,
    Refunded,
    StockOut,
    Cancelled
}

public enum PaymentStatus
{
    Pending,
    Success,
    Failed
}

public enum AdminRole
{
    SuperAdmin,         // Full access — all modules
    InventoryManager,   // Items + Stock only
    OrderManager        // Orders only
}

public enum SupplyType
{
    IntraState = 1,  // Seller State == Customer State -> CGST + SGST
    InterState = 2   // Seller State != Customer State -> IGST
}
