using Himgiri.Core.Enums;

namespace Himgiri.Core.Entities;

public class Item : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public decimal Price { get; set; }          // Base price excluding GST
    public StorageStatus StorageStatus { get; set; } = StorageStatus.InStock;
    public int StockQty { get; set; } = 0;
    
    // Links to Dynamic Support Entities
    public Guid CategoryId { get; set; }
    public ItemCategory Category { get; set; } = null!;
    
    public Guid GradeId { get; set; }
    public Grade Grade { get; set; } = null!;

    // Navigation
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public ICollection<StockLog> StockLogs { get; set; } = new List<StockLog>();
    public ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();
}
