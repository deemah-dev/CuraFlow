using CuraFlow.Application.Features.Employees.Dtos;
using CuraFlow.Domain.Common.Enums;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Employees.Queries.GetEmployees;

public sealed record GetEmployeesQuery(Role Role) : IRequest<Result<List<EmployeeDto>>>;