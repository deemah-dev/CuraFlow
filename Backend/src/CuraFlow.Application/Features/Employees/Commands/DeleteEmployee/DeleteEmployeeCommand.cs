using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Employees.Commands.DeleteEmployee;

public sealed record DeleteEmployeeCommand(Guid EmployeeId) : IRequest<Result<Deleted>>;