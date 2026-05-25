namespace Himgiri.Core.Entities;

public class ItemCategory : BaseEntity
{
    public string Name { get; set; } = string.Empty;          // "Textbook", "Stationery"
    public string Description { get; set; } = string.Empty;   // Optional — shown in admin panel
    public string HsnCode { get; set; } = string.Empty;       // "4901", "4820", "4202"
    public decimal GstPercent { get; set; }                    // 0, 5, 12, 18 only
    public decimal CgstPercent { get; set; }                   // = GstPercent / 2 — set in service
    public decimal SgstPercent { get; set; }                   // = GstPercent / 2 — set in service
    public bool IsTaxable { get; set; } = true;                // false only when GstPercent = 0
    public int DisplayOrder { get; set; } = 0;                 // controls dropdown sort order
    
    // Navigation
    public ICollection<Item> Items { get; set; } = new List<Item>();
}
