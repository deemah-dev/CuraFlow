using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Appointments.Commands.DeleteAppointment;

public sealed record DeleteAppointmentCommand(Guid AppointmentId) : IRequest<Result<Deleted>>;