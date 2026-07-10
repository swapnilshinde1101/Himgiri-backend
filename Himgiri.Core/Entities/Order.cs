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
    public Guid? GradeId { get; set; }
    public Grade? Grade { get; set; }
    public string GradeName { get; set; } = string.Empty; // snapshot at order time

    public string? CustomerGstin { get; set; } // Snapshot of customer GSTIN
    
    // Relational State bindings
    public Guid SellerStateId { get; set; }
    public State? SellerState { get; set; }
    
    public Guid CustomerStateId { get; set; }
    public State? CustomerState { get; set; }
    
    // Immutable snapshots
    public string SellerCompanyName { get; set; } = string.Empty;
    public string? SellerGstin { get; set; }
    public string SellerAddress { get; set; } = string.Empty;
    public string SellerStateName { get; set; } = string.Empty;
    public string SellerGstStateCode { get; set; } = string.Empty;
    
    public string CustomerStateName { get; set; } = string.Empty;
    public string CustomerGstStateCode { get; set; } = string.Empty;
    
    public string PlaceOfSupply { get; set; } = string.Empty;
    public string PlaceOfSupplyCode { get; set; } = string.Empty;
    
    public SupplyType SupplyType { get; set; }
    public bool IsHomeDelivery { get; set; }

    public decimal SubTotal { get; set; }       // Sum of item prices before GST
    public decimal TotalGst { get; set; }       // Total GST amount
    public decimal DeliveryFee { get; set; }    // 250 flat (or 0 if no delivery items)
    public decimal DeliveryGst { get; set; }    // GST on delivery fee
    public decimal DeliveryCgstAmount { get; set; }
    public decimal DeliverySgstAmount { get; set; }
    public decimal DeliveryIgstAmount { get; set; }
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
    public decimal BaseAmount { get; set; }     // UnitPrice * Quantity (before GST)
    
    // GST Split snapshots
    public decimal GstPercent { get; set; }
    public decimal CgstPercent { get; set; }
    public decimal SgstPercent { get; set; }
    public decimal IgstPercent { get; set; }
    public decimal CessPercent { get; set; }

    public decimal GstAmount { get; set; }      // Total GST for this line
    public decimal CgstAmount { get; set; }     // CGST portion
    public decimal SgstAmount { get; set; }     // SGST portion
    public decimal IgstAmount { get; set; }     // IGST portion
    public decimal CessAmount { get; set; }     // Cess portion
    
    public SupplyType SupplyType { get; set; }  // Tax type resolved at checkout
    public decimal LineTotal { get; set; }      // (UnitPrice + GstAmount) * Quantity
    public bool IsKitItem { get; set; }
}
