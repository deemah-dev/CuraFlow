namespace CuraFlow.Infrastructure.Data;

using System.Reflection;

using CuraFlow.Application.Common.Interfaces;
using CuraFlow.Domain.Appointments;
using CuraFlow.Domain.Common;
using CuraFlow.Domain.Employees;
using CuraFlow.Domain.MedicalDepartments;
using CuraFlow.Domain.MedicalRecords;
using CuraFlow.Domain.Patients;
using CuraFlow.Domain.Tenants;
using CuraFlow.Infrastructure.Identity;
using CuraFlow.Infrastructure.Tenancy;

using MediatR;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

public class AppDbContext(DbContextOptions<AppDbContext> options,
                            TenantContext tenantContext,
                            IMediator mediator) : IdentityDbContext<AppUser>(options), IAppDbContext
{
    public DbSet<Appointment> Appointments => Set<Appointment>();

    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<MedicalDepartment> MedicalDepartments => Set<MedicalDepartment>();

    public DbSet<MedicalRecord> MedicalRecords => Set<MedicalRecord>();

    public DbSet<Patient> Patients => Set<Patient>();

    public DbSet<Tenant> Tenants => Set<Tenant>();

    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        PublishDomainEvents(cancellationToken);
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (entityType.IsOwned())
            {
                continue;
            }

            IndexOnTenantId(builder, entityType);
            ImplementGlobalQueryFilter(builder, entityType);
        }

        base.OnModelCreating(builder);
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

    private void IndexOnTenantId(ModelBuilder builder, IMutableEntityType entityType)
    {
        var tenantIdProperty = entityType.FindProperty("TenantId");

        if (tenantIdProperty != null && tenantIdProperty.ClrType == typeof(Guid))
        {
            builder.Entity(entityType.ClrType)
                        .HasIndex("TenantId");
        }
    }

    private void ImplementGlobalQueryFilter(ModelBuilder builder, IMutableEntityType entityType)
    {
        if (typeof(Entity).IsAssignableFrom(entityType.ClrType))
        {
            var method = typeof(AppDbContext)
                .GetMethod(
                    nameof(SetGlobalQueryFilter),
                    BindingFlags.NonPublic | BindingFlags.Instance)!
                .MakeGenericMethod(entityType.ClrType);

            method.Invoke(this, [builder]);
        }
    }

    private void SetGlobalQueryFilter<TEntity>(ModelBuilder modelBuilder)
    where TEntity : Entity
    {
        modelBuilder.Entity<TEntity>()
            .HasQueryFilter(e => e.TenantId == tenantContext.CurrentTenantId);
    }
}