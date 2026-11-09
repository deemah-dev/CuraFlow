using CuraFlow.Domain.Common.Results;

namespace CuraFlow.Domain.Tenants;

public class Tenant
{
    private Tenant(Guid id, string name, string identifier)
    {
        Id = id == Guid.Empty ? Guid.NewGuid() : id;
        Name = name;
        Identifier = identifier;
        IsActive = false;
        CreatedAt = DateTimeOffset.UtcNow;
    }

    private Tenant() { }

    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Identifier { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset ModifiedAt { get; private set; }

    public static Result<Tenant> Create(Guid id, string name, string identifier)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return TenantErrors.NameRequired;
        }

        if (string.IsNullOrWhiteSpace(identifier))
        {
            return TenantErrors.IdentifierRequired;
        }

        return new Tenant(id, name, identifier);
    }
}