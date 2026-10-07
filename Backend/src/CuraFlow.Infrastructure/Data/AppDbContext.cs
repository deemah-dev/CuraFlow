namespace CuraFlow.Infrastructure.Data;

using CuraFlow.Application.Common.Interfaces;
using CuraFlow.Domain.Common;
using CuraFlow.Infrastructure.Identity;

using MediatR;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator) : IdentityDbContext<AppUser>(options), IAppDbContext
{
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        PublishDomainEvents(cancellationToken);
        return base.SaveChangesAsync(cancellationToken);
    }

    private void PublishDomainEvents(CancellationToken cancellationToken)
    {
        var domainEntities = ChangeTracker.Entries().Where(e => e.Entity is Entity entity && entity.DomainEvents.Count() != 0).Select(e => (Entity)e.Entity).ToList();

        var domainEvents = domainEntities.SelectMany(e => e.DomainEvents).ToList();
        foreach (var @event in domainEvents)
        {
            mediator.Publish(@event, cancellationToken);
        }

        foreach (var entity in domainEntities)
        {
            entity.ClearDomainEvents();
        }
    }
}