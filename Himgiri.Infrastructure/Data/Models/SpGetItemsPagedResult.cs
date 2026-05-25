namespace Himgiri.Infrastructure.Data.Models;

public class SpGetItemsPagedResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    public Guid GradeId { get; set; }
    public string GradeName { get; set; } = null!;
    public int StorageStatus { get; set; }
    public int StockQty { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public int TotalCount { get; set; }
}
