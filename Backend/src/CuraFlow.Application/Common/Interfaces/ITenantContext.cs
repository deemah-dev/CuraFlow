namespace CuraFlow.Application.Common.Interfaces;

public interface ITenantContext
{
    public Guid CurrentTenantId { get; set; }
    public string Identifier { get; set; }
    public bool IsActive { get; set; }
}