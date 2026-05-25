namespace Himgiri.Core.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    // Status
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;

    // Audit Timestamps
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    // Audit Users
    public Guid? CreatedBy { get; set; }
    public Guid? ModifiedBy { get; set; }
    public Guid? DeletedBy { get; set; }
}
