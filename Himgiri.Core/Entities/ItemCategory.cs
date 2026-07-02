namespace Himgiri.Core.Entities;

public class ItemCategory : BaseEntity
{
    public string Name { get; set; } = string.Empty;          // "Textbook", "Stationery"
    public string Description { get; set; } = string.Empty;   // Optional — shown in admin panel
    public int DisplayOrder { get; set; } = 0;                 // controls dropdown sort order
    
    // Navigation
    public Guid DefaultGstRateId { get; set; }
    public GstRate DefaultGstRate { get; set; } = null!;

    public ICollection<Item> Items { get; set; } = new List<Item>();
}
