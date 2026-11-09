using CuraFlow.Domain.Common.Results;

namespace CuraFlow.Domain.Tenants;

public class TenantErrors
{
    internal static readonly Error NameRequired = Error.Validation("Tenant.Name");
    internal static readonly Error IdentifierRequired = Error.Validation("Tenant.Identifier");
}