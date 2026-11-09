using CuraFlow.Application.Features.Patients.Dtos;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Patients.Queries.GetPatient;

public sealed record GetPatinetQuery(Guid PatinetId) : IRequest<Result<PatientDto>>;