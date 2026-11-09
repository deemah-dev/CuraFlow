using CuraFlow.Domain.Common.Enums;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Features.Employees.Commands.UpdateEmployee;

public sealed record UpdateEmployeeCommand(Guid EmployeeId,
                                            string FirstName,
                                            string LastName,
                                            string Address,
                                            string PhoneNumber,
                                            string Email,
                                            Role Role) : IRequest<Result<Updated>>;