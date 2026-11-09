using CuraFlow.Application.Features.Employees.Commands.CreateEmployee;
using CuraFlow.Application.Features.Employees.Commands.DeleteEmployee;
using CuraFlow.Application.Features.Employees.Commands.UpdateEmployee;
using CuraFlow.Application.Features.Employees.Dtos;
using CuraFlow.Domain.Common.Results;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CuraFlow.Api.Controllers.V1;

[Route("/employees")]
public class EmployeeController(ISender sender) : ApiController
{
    [HttpPost]
    [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Creates an employee.")]
    [EndpointDescription("Creates an employee with the supplied personal, contact, and role information.")]
    [EndpointName("CreateEmployee")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Create(CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpDelete("{employeeId:guid}")]
    [ProducesResponseType(typeof(Deleted), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Deletes an employee.")]
    [EndpointDescription("Deletes the employee with the specified employee ID.")]
    [EndpointName("DeleteEmployee")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Delete(Guid employeeId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteEmployeeCommand(employeeId), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(Updated), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Updates an employee.")]
    [EndpointDescription("Updates the employee details and role. The route ID must match the employee ID in the command.")]
    [EndpointName("UpdateEmployee")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Update(Guid id, UpdateEmployeeCommand command, CancellationToken cancellationToken)
    {
        if (id != command.EmployeeId)
        {
            return Problem([Error.Failure("Employee.Id", "The Id that provided in the query does not match the one in the request")]);
        }

        var result = await sender.Send(command, cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }
}