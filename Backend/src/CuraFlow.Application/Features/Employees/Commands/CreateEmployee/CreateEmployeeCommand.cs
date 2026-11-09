using CuraFlow.Application.Features.Employees.Dtos;
using CuraFlow.Domain.Common.Enums;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Employees.Commands.CreateEmployee;

public sealed record CreateEmployeeCommand(string FirstName,
                                            string LastName,
                                            string Address,
                                            string PhoneNumber,
                                            string Email,
                                            Role Role) : IRequest<Result<EmployeeDto>>;