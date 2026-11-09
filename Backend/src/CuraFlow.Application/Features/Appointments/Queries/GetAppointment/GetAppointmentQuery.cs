using CuraFlow.Application.Features.Appointments.Dtos;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Appointments.Queries.GetAppointment;

public sealed record GetAppointmentQuery(Guid AppointmentId) : IRequest<Result<AppointmentDto>>;