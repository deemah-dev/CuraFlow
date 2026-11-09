using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.MedicalDepartment.Commands.DeleteMedicalDepartment;

public sealed record DeleteMedicalDepartmentCommand(Guid MedicalDepartmentId) : IRequest<Result<Deleted>>;