namespace Himgiri.Infrastructure.Data.Models;

public class SpGetItemsPagedResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public decimal Price { get; set; }
    public decimal? PurchasePrice { get; set; }
    public decimal Mrp { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    public string GradeIds { get; set; } = string.Empty;
    public string GradeNames { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public int StorageStatus { get; set; }
    public int StockQty { get; set; }
    public int TargetQty { get; set; }
    public bool IsActive { get; set; }
    public bool IsStockInitialized { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public int TotalCount { get; set; }
}
