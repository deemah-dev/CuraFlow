namespace CuraFlow.Domain.Common;

public class AuditableEntity : Entity
{
    protected AuditableEntity()
    { }

    protected AuditableEntity(Guid id)
        : base(id)
    { }
    public string? CreatedBy { get; set; }
    public DateTimeOffset CreatedAtUtc { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTimeOffset LastModifiedAtUtc { get; set; }
}