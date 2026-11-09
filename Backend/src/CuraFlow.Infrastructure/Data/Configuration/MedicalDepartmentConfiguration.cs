using CuraFlow.Domain.MedicalDepartments;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CuraFlow.Infrastructure.Data.Configuration;

public class MedicalDepartmentConfiguration : IEntityTypeConfiguration<MedicalDepartment>
{
    public void Configure(EntityTypeBuilder<MedicalDepartment> builder)
    {
        builder.ToTable("MedicalDepartments");
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id).ValueGeneratedNever();

        builder.Property(m => m.BaseConsultationFee);
        builder.Property(m => m.DefaultDurationMinutes);
        builder.Property(m => m.Description);
        builder.Property(m => m.IsActive);
        builder.Property(m => m.Name);
    }
}