using CuraFlow.Domain.Appointments;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Appointments.Commands.UpdateAppointmentStatus;

public sealed record UpdateAppointmentStatusCommand(Guid AppointmentId, AppointmentStatus NewStatus) : IRequest<Result<Updated>>;