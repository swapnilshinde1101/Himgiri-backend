namespace Himgiri.Core.Constants;

public static class StockReasons
{
    public const string ManualUpdate = "Manual Update";
    public const string OrderPlaced = "Order Placed";
    public const string OrderCancelled = "Order Cancelled";
    public const string PurchaseReceived = "Purchase Received";
    public const string PurchaseCancelled = "Purchase Cancelled";

    public static readonly IReadOnlySet<string> AllReasons = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        ManualUpdate,
        OrderPlaced,
        OrderCancelled,
        PurchaseReceived,
        PurchaseCancelled
    };
}
