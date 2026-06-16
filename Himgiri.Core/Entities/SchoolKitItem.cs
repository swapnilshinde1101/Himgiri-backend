using System;

namespace Himgiri.Core.Entities;

public class SchoolKitItem
{
    public Guid SchoolKitId { get; set; }
    public SchoolKit SchoolKit { get; set; } = null!;

    public Guid ItemId { get; set; }
    public Item Item { get; set; } = null!;

    // Defines how many of this item are included in the bundle kit
    public int Quantity { get; set; }
}
