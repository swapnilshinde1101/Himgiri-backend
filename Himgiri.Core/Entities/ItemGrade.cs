namespace Himgiri.Core.Entities;

public class ItemGrade
{
    public Guid ItemId { get; set; }
    public Item Item { get; set; } = null!;
    
    public Guid GradeId { get; set; }
    public Grade Grade { get; set; } = null!;
}
