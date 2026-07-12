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
}