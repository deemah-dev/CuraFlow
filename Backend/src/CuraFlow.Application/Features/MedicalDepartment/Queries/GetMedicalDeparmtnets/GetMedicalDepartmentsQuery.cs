using CuraFlow.Application.Common.Models;
using CuraFlow.Application.Features.MedicalDepartment.Dtos;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.MedicalDepartment.Queries.GetMedicalDeparmtnets;

public sealed record GetMedicalDepartmentsQuery() : IRequest<Result<PagenatedList<MedicalDepartmentDto>>>;