using CuraFlow.Application.Features.MedicalDepartment.Dtos;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.MedicalDepartment.Queries.GetMedicalDepartment;

public sealed record GetMedicalDeparmtnetQuery(Guid MedicalDepartmentId) : IRequest<Result<MedicalDepartmentDto>>;