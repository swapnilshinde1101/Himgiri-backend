using Himgiri.Core.Enums;

namespace Himgiri.Core.Entities;

public class Order : BaseEntity
{
    public string InvoiceNumber { get; set; } = string.Empty; // HG-2026-0001
    public string CustomerName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public string AddressLine1 { get; set; } = string.Empty;
    public string AddressLine2 { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Pincode { get; set; } = string.Empty;
    public int Grade { get; set; }

    public decimal SubTotal { get; set; }       // Sum of item prices before GST
    public decimal TotalGst { get; set; }       // Total GST amount
    public decimal DeliveryFee { get; set; }    // 250 flat (or 0 if no delivery items)
    public decimal DeliveryGst { get; set; }    // GST on delivery fee
    public decimal GrandTotal { get; set; }     // Final amount charged to customer

    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;
    public string? JodoPaymentId { get; set; }
    public string? AdminNotes { get; set; }
    public bool IsRefunded { get; set; } = false;
    public string? RefundReason { get; set; }

    // Navigation
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}

public class OrderItem : BaseEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public Guid ItemId { get; set; }
    public Item Item { get; set; } = null!;

    public string ItemName { get; set; } = string.Empty; // Snapshot at time of order
    public string HsnCode { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }      // Price at time of order
    public decimal GstPercent { get; set; }
    public decimal GstAmount { get; set; }      // Total GST for this line
    public decimal Cgst { get; set; }           // Half of GstAmount
    public decimal Sgst { get; set; }           // Half of GstAmount
    public decimal LineTotal { get; set; }      // (UnitPrice + GstAmount) * Quantity
}
