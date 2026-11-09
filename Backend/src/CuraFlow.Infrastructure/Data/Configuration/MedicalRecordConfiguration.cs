using CuraFlow.Domain.MedicalDepartments;
using CuraFlow.Domain.MedicalRecords;
using CuraFlow.Domain.Patients;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CuraFlow.Infrastructure.Data.Configuration;

public class MedicalRecordfiguration : IEntityTypeConfiguration<MedicalRecord>
{
    public void Configure(EntityTypeBuilder<MedicalRecord> builder)
    {
        builder.ToTable("MedicalRecords");
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id).ValueGeneratedNever();

        builder.Property(m => m.Allergies);
        builder.Property(m => m.BloodType).HasConversion<string>();
        builder.Property(m => m.ChronicDiseases);
        builder.Property(m => m.FamilyHistory);
        builder.Property(m => m.SurgicalHistory);

        builder.HasOne(m => m.Patient).WithOne().HasForeignKey<MedicalRecord>(m => m.PatientId);
    }
}