namespace CHMS.Domain.Abstractions.Base;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        CreatedAt = DateTime.Now;
        LastUpdated = null;
    }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? LastUpdated { get; set; }
}
