using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Patients.Commands.DeletePatient;

public sealed record DeletePatientCommand(Guid PatientId) : IRequest<Result<Deleted>>;