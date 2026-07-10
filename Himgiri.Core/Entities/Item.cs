using System.ComponentModel.DataAnnotations;
using Himgiri.Core.Enums;

namespace Himgiri.Core.Entities;

public class Item : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public decimal Price { get; set; }          // Base price excluding GST (Selling Price)
    public decimal? PurchasePrice { get; set; }  // Purchase price (optional)
    public decimal Mrp { get; set; }            // Maximum Retail Price (Required, inclusive of GST)
    public StorageStatus StorageStatus { get; set; } = StorageStatus.InStock;

    [ConcurrencyCheck]
    public int StockQty { get; set; } = 0;
    public int TargetQty { get; set; } = 0;
    public bool IsStockInitialized { get; set; } = false;
    public string Unit { get; set; } = "Pieces (Pcs)";
    public int? LowStockThreshold { get; set; }
    public DateTime? CompletedAt { get; set; }
    
    // Links to Dynamic Support Entities
    public Guid CategoryId { get; set; }
    public ItemCategory Category { get; set; } = null!;
    
    public Guid? GstRateId { get; set; }
    public GstRate? GstRate { get; set; }
    
    public ICollection<ItemGrade> ItemGrades { get; set; } = new List<ItemGrade>();

    // Navigation
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public ICollection<StockLog> StockLogs { get; set; } = new List<StockLog>();
    public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();
}
