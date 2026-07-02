namespace Himgiri.Core.Entities;

public class Grade : BaseEntity
{
    public string Name { get; set; } = string.Empty;          // "Grade 1", "LKG"
    public string ShortName { get; set; } = string.Empty;     // "G1"
    public string Description { get; set; } = string.Empty;    // Optional info
    public bool IsActive { get; set; } = true;                 // Status toggle
    public int DisplayOrder { get; set; } = 0;                 // For sorting LKG, UKG, G1, G2...
    
    // Navigation
    public ICollection<ItemGrade> ItemGrades { get; set; } = new List<ItemGrade>();
}
