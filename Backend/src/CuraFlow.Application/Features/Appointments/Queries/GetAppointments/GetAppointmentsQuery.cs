using CuraFlow.Application.Common.Interfaces;
using CuraFlow.Application.Common.Models;
using CuraFlow.Application.Features.Appointments.Dtos;
using CuraFlow.Domain.Appointments;
using CuraFlow.Domain.Common.Results;

namespace CuraFlow.Application.Features.Appointments.Queries.GetAppointments;

public sealed record GetAppointmentsQuery(
    int Page,
    int PageSize,
    string? SearchTerm,
    string SortColumn = "createdAt",
    string SortDirection = "desc",
    AppointmentStatus? Status = null,
    Guid? PatientId = null,
    Guid? DoctorId = null,
    DateTime? StartDateFrom = null,
    DateTime? StartDateTo = null) : ICachedQuery<Result<PagenatedList<AppointmentDto>>>
{
    public string CacheKey => $"appointments-{SearchTerm}-{SortColumn}-{SortDirection}-{Status}-{PatientId}-{DoctorId}-{StartDateFrom}-{StartDateTo}";

    public string[] Tags => ["appointments"];

    public TimeSpan Expiration => TimeSpan.FromMinutes(30);
}