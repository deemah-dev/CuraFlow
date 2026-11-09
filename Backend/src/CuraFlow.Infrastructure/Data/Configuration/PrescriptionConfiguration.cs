using CuraFlow.Domain.Visits;
using CuraFlow.Domain.Visits.Prescriptions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CuraFlow.Infrastructure.Data.Configuration;

public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.ToTable("Prescriptions");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).ValueGeneratedNever();

        builder.Property(p => p.Dosage);
        builder.Property(p => p.EndDate);
        builder.Property(p => p.Frequency);
        builder.Property(p => p.MeditionName);
        builder.Property(p => p.SpecialInstructions);
        builder.Property(p => p.StartDate);
    }
}