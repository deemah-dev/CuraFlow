using CuraFlow.Application.Features.Appointments.Dtos;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Appointments.Commands.CreateAppointmet;

public sealed record CreateAppointmentCommand(Guid PatientId, Guid DoctorId, Guid MedicalDepartmentId, DateTimeOffset AppointmentDate) : IRequest<Result<AppointmentDto>>;