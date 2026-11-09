using CuraFlow.Application.Common.Interfaces;
using CuraFlow.Application.Features.Employees.Dtos;
using CuraFlow.Application.Features.Employees.Meppers;
using CuraFlow.Application.Features.Identity.Dtos;
using CuraFlow.Domain.Common.Results;
using CuraFlow.Domain.Employees;

using MediatR;

namespace CuraFlow.Application.Features.Employees.Commands.CreateEmployee;

public class CreateEmployeeCommandHandler(IAppDbContext context, IIdentityService identityService) : IRequestHandler<CreateEmployeeCommand, Result<EmployeeDto>>
{
    public async Task<Result<EmployeeDto>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var createEmployeeResult = Employee.Create(Guid.Empty, request.FirstName, request.LastName, request.Address, request.PhoneNumber, request.Email, request.Role);
        if (createEmployeeResult.IsError)
        {
            return createEmployeeResult.Errors;
        }

        var employee = createEmployeeResult.Value;
        UserDto user = new();

        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await context.Employees.AddAsync(employee, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            var createUserResult = await identityService.RegisterUserAsync(
                                                                        request.Email,
                                                                        request.Email,
                                                                        request.PhoneNumber,
                                                                        request.Email);

            if (createUserResult.IsError)
            {
                return createUserResult.Errors;
            }

            user = createUserResult.Value;

            await transaction.CommitAsync(cancellationToken);
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            return Error.Failure("Employee.Create", "Failed to add new employee & user");
        }

        return employee.ToDto(user);
    }
}