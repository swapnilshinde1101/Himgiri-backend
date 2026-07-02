using System;

namespace Himgiri.Core.Entities;

public class PriceAuditLog : BaseEntity
{
    public Guid ItemId { get; set; }
    public Item Item { get; set; } = null!;

    public decimal OldPrice { get; set; }
    public decimal NewPrice { get; set; }

    public decimal OldMrp { get; set; }
    public decimal NewMrp { get; set; }

    public string ChangedBy { get; set; } = string.Empty; // Admin email/name
    public string Reason { get; set; } = string.Empty;    // "Manual price adjustment" etc.
}
