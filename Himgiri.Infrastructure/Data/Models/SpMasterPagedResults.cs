namespace Himgiri.Infrastructure.Data.Models;

public class SpGetGradesPagedResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public string? Description { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public int TotalCount { get; set; }
}

public class SpGetCategoriesPagedResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public int DisplayOrder { get; set; }
    public string HsnCode { get; set; } = null!;
    public decimal GstPercent { get; set; }
    public decimal CgstPercent { get; set; }
    public decimal SgstPercent { get; set; }
    public bool IsTaxable { get; set; }
    public DateTime CreatedAt { get; set; }
    public int TotalCount { get; set; }
}
