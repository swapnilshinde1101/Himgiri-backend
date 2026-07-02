namespace Himgiri.Core.Models;

public class BaseRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SearchTerm { get; set; }
    public string? SortColumn { get; set; }
    public string SortDirection { get; set; } = "ASC"; // ASC or DESC
    public bool OnlyInitializedStock { get; set; } = false;

    // Advanced Filters
    public Guid? CategoryId { get; set; }
    public Guid? GradeId { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? StockStatus { get; set; }
    public bool? IsCompleted { get; set; }
}
