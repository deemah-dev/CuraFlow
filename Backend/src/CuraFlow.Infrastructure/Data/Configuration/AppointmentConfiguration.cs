using CuraFlow.Domain.Appointments;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CuraFlow.Infrastructure.Data.Configuration;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointments");
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).ValueGeneratedNever();

        builder.Property(a => a.AppoinmentDate);

        builder.HasOne(a => a.Doctor).WithMany().HasForeignKey(a => a.DoctorId);
        builder.HasOne(a => a.Department).WithMany().HasForeignKey(a => a.MedicalDepartmentId);
        builder.HasOne(a => a.Patient).WithMany().HasForeignKey(a => a.PatientId);

        builder.Property(a => a.Status).HasConversion<string>();

        builder.HasIndex(e => e.DoctorId).IsUnique(false);
        builder.HasIndex(e => e.MedicalDepartmentId).IsUnique(false);
        builder.HasIndex(e => e.PatientId).IsUnique(false);
        builder.HasIndex(e => e.Status).IsUnique(false);
    }
}