using CuraFlow.Application.Common.Models;
using CuraFlow.Application.Features.Visits.Commands.CreateVisit;
using CuraFlow.Application.Features.Visits.Commands.DeleteVisit;
using CuraFlow.Application.Features.Visits.Commands.UpdateVisit;
using CuraFlow.Application.Features.Visits.Dtos;
using CuraFlow.Application.Features.Visits.Queries.GetVisit;
using CuraFlow.Application.Features.Visits.Queries.GetVisits;
using CuraFlow.Domain.Common.Results;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CuraFlow.Api.Controllers.V1;

[Route("/visits")]
public class VisitController(ISender sender) : ApiController
{
    [HttpPost]
    [ProducesResponseType(typeof(VisitDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Creates a visit.")]
    [EndpointDescription("Creates a visit for the specified medical record, department, doctor, diagnosis, and visit date, with optional prescriptions.")]
    [EndpointName("CreateVisit")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Create(CreateVisitCommand command, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpDelete("{visitId:guid}")]
    [ProducesResponseType(typeof(Deleted), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Deletes a visit.")]
    [EndpointDescription("Deletes the visit with the specified visit ID.")]
    [EndpointName("DeleteVisit")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Delete(Guid visitId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteVisitCommand(visitId), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagenatedList<VisitDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Lists visits.")]
    [EndpointDescription("Returns the paginated list of visits.")]
    [EndpointName("GetVisits")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetList(CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetVisitsQuery(), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpGet("{visitId:guid}")]
    [ProducesResponseType(typeof(VisitDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(PrescriptionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Gets a visit by ID.")]
    [EndpointDescription("Returns the visit with the specified visit ID.")]
    [EndpointName("GetVisit")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Get(Guid visitId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetVisitQuery(visitId), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(Updated), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Updates a visit.")]
    [EndpointDescription("Updates the visit diagnosis, chief complaint, symptoms, and prescriptions. The route ID must match the visit ID in the command.")]
    [EndpointName("UpdateVisit")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Update(Guid id, UpdateVisitCommand command, CancellationToken cancellationToken)
    {
        if (id != command.VisitId)
        {
            return Problem([Error.Failure("Visit.Id", "The Id that provided in the query does not match the one in the request")]);
        }

        var result = await sender.Send(command, cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }
}