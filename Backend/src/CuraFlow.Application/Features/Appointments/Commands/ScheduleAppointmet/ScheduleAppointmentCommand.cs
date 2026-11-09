using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Appointments.Commands.ScheduleAppointmet;

public sealed record ScheduleAppointmentCommand(Guid AppointmentId, DateTimeOffset NewAppointmentDate) : IRequest<Result<Updated>>;