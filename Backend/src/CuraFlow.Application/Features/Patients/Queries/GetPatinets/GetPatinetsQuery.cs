using CuraFlow.Application.Common.Models;
using CuraFlow.Application.Features.Patients.Dtos;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Patients.Queries.GetPatinets;

public sealed record GetPatinetsQuery() : IRequest<Result<PagenatedList<PatientDto>>>;