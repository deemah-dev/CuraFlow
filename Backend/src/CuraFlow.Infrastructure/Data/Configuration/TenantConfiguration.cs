using CuraFlow.Domain.Tenants;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CuraFlow.Infrastructure.Data.Configuration;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable("Tenants");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedNever();

        builder.Property(t => t.CreatedAt);
        builder.Property(t => t.Identifier);
        builder.Property(t => t.IsActive);
        builder.Property(t => t.ModifiedAt);
        builder.Property(t => t.Name);
    }
}