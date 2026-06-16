using System;
using System.Collections.Generic;

namespace Himgiri.Core.Entities;

public class SchoolKit : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    
    // The Grade this kit is designed for
    public Guid GradeId { get; set; }
    public Grade Grade { get; set; } = null!;

    // Navigation property for constituent items
    public ICollection<SchoolKitItem> KitItems { get; set; } = new List<SchoolKitItem>();
}
