using CuraFlow.Domain.Appointments;
using CuraFlow.Domain.Employees;
using CuraFlow.Domain.MedicalDepartments;
using CuraFlow.Domain.MedicalRecords;
using CuraFlow.Domain.Patients;
using CuraFlow.Domain.Tenants;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CuraFlow.Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<Appointment> Appointments { get; }
    DbSet<Employee> Employees { get; }
    DbSet<MedicalDepartment> MedicalDepartments { get; }
    DbSet<MedicalRecord> MedicalRecords { get; }
    DbSet<Patient> Patients { get; }
    DbSet<Tenant> Tenants { get; }
    DbSet<RefreshToken> RefreshTokens { get; }
    Task<int> SaveChangesAsync(CancellationToken ct);
    DatabaseFacade Database { get; }
}