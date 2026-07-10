using Himgiri.Core.Enums;

namespace Himgiri.Core.Entities;

public class AdminUser : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public AdminRole Role { get; set; } = AdminRole.OrderManager;
    public DateTime? LastLoginAt { get; set; }
    
    // Brute Force Protection
    public int AccessFailedCount { get; set; } = 0;
    public DateTime? LockoutEnd { get; set; }
}

public class StockLog : BaseEntity
{
    public Guid ItemId { get; set; }
    public Item Item { get; set; } = null!;
    public int OldQty { get; set; }
    public int NewQty { get; set; }
    public string ChangedBy { get; set; } = string.Empty; // Admin name
    public string Reason { get; set; } = string.Empty;    // "Manual update" / "Order placed" / "Purchase received"
    public string Note { get; set; } = string.Empty;
}

public class Supplier : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string ContactNumber { get; set; } = string.Empty;
    public string GstNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
}

public class PurchaseOrder : BaseEntity
{
    public Guid SupplierId { get; set; }
    public Supplier Supplier { get; set; } = null!;
    public string SupplierInvoiceNo { get; set; } = string.Empty;
    public DateTime PurchaseDate { get; set; }
    public decimal TotalCost { get; set; }
    public string Notes { get; set; } = string.Empty;
    public bool IsCancelled { get; set; } = false;

    public ICollection<PurchaseOrderItem> Items { get; set; } = new List<PurchaseOrderItem>();
}

public class PurchaseOrderItem : BaseEntity
{
    public Guid PurchaseOrderId { get; set; }
    public PurchaseOrder PurchaseOrder { get; set; } = null!;
    public Guid ItemId { get; set; }
    public Item Item { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal UnitCost { get; set; }
    public decimal LineTotal { get; set; } // Quantity * UnitCost
}

public class VendorSettings : BaseEntity
{
    public string CompanyName { get; set; } = "Himgiri Goods Pvt. Ltd";
    public string Gstin { get; set; } = string.Empty;       // Pending from client
    public string Address { get; set; } = string.Empty;
    public string ContactEmail { get; set; } = string.Empty;
    public string ContactPhone { get; set; } = string.Empty;
    public string InvoicePrefix { get; set; } = "HG";
    public int LastInvoiceNumber { get; set; } = 0;
    public int DefaultLowStockThreshold { get; set; } = 10;

    // Navigation
    public Guid? StateId { get; set; }
    public State? State { get; set; }
}

public class OrderStatusHistory : BaseEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public OrderStatus FromStatus { get; set; }
    public OrderStatus ToStatus { get; set; }
    public string ChangedBy { get; set; } = string.Empty;
    public string? Note { get; set; }
}
