using System.Collections.ObjectModel;

namespace CuraFlow.Domain.Common;

public class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    protected Entity(Guid id)
    {
        Id = id == Guid.Empty ? Guid.NewGuid() : id;
    }

    public Guid Id { get; }
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    private readonly List<DomainEvent> _domainEvents = [];

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void AddDomainEvent(DomainEvent @event)
    {
        _domainEvents.Add(@event);
    }

    protected void RemoveDomainEvent(DomainEvent @event)
    {
        _domainEvents.Remove(@event);
    }
}