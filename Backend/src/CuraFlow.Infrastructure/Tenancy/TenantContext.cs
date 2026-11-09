using CuraFlow.Application.Common.Interfaces;

namespace CuraFlow.Infrastructure.Tenancy;

public class TenantContext : ITenantContext
{
    public Guid CurrentTenantId { get; set; }
    public string Identifier { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public void SetTenant(Guid tenantId, string identifier, bool isActive)
    {
        CurrentTenantId = tenantId;
        Identifier = identifier;
        IsActive = isActive;
    }
}