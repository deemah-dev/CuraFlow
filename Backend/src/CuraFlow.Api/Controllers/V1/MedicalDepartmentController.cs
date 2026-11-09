using CuraFlow.Application.Common.Models;
using CuraFlow.Application.Features.MedicalDepartment.Commands.CreateMedicalDepartment;
using CuraFlow.Application.Features.MedicalDepartment.Commands.DeleteMedicalDepartment;
using CuraFlow.Application.Features.MedicalDepartment.Commands.UpdateMedicalDepartment;
using CuraFlow.Application.Features.MedicalDepartment.Dtos;
using CuraFlow.Application.Features.MedicalDepartment.Queries.GetMedicalDeparmtnets;
using CuraFlow.Application.Features.MedicalDepartment.Queries.GetMedicalDepartment;
using CuraFlow.Domain.Common.Results;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CuraFlow.Api.Controllers.V1;

[Route("/medical-departments")]
public class MedicalDepartmentController(ISender sender) : ApiController
{
    [HttpPost]
    [ProducesResponseType(typeof(MedicalDepartmentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Creates a medical department.")]
    [EndpointDescription("Creates a medical department with its name, consultation fee, default duration, and description.")]
    [EndpointName("CreateMedicalDepartment")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Create(CreateMedicalDepartmentCommand command, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpDelete("{medicalDepartmentId:guid}")]
    [ProducesResponseType(typeof(Deleted), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Deletes a medical department.")]
    [EndpointDescription("Deletes the medical department with the specified ID.")]
    [EndpointName("DeleteMedicalDepartment")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Delete(Guid medicalDepartmentId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteMedicalDepartmentCommand(medicalDepartmentId), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagenatedList<MedicalDepartmentDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Lists medical departments.")]
    [EndpointDescription("Returns the paginated list of medical departments.")]
    [EndpointName("GetMedicalDepartments")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetList(CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetMedicalDepartmentsQuery(), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpGet("{medicalDepartmentId:guid}")]
    [ProducesResponseType(typeof(MedicalDepartmentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Gets a medical department by ID.")]
    [EndpointDescription("Returns the medical department with the specified ID.")]
    [EndpointName("GetMedicalDepartment")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Get(Guid medicalDepartmentId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetMedicalDeparmtnetQuery(medicalDepartmentId), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(Updated), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Updates a medical department.")]
    [EndpointDescription("Updates the medical department details. The route ID must match the ID in the command.")]
    [EndpointName("UpdateMedicalDepartment")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Update(Guid id, UpdateMedicalDepartmentCommand command, CancellationToken cancellationToken)
    {
        if (id != command.MedicalDeparmtnetId)
        {
            return Problem([Error.Failure("MedicalDeparmtnet.Id", "The Id that provided in the query does not match the one in the request")]);
        }

        var result = await sender.Send(command, cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }
}