using CuraFlow.Application.Common.Models;
using CuraFlow.Application.Features.Treatments.Commands.CreateTreatment;
using CuraFlow.Application.Features.Treatments.Commands.DeleteTreatment;
using CuraFlow.Application.Features.Treatments.Commands.UpdateTreatment;
using CuraFlow.Application.Features.Treatments.Dtos;
using CuraFlow.Application.Features.Treatments.Queries.GetTreatment;
using CuraFlow.Application.Features.Treatments.Queries.GetTreatments;
using CuraFlow.Domain.Common.Results;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CuraFlow.Api.Controllers.V1;

[Route("/treatments")]
public class TreatmentController(ISender sender) : ApiController
{
    [HttpPost]
    [ProducesResponseType(typeof(TreatmentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Creates a treatment.")]
    [EndpointDescription("Creates a treatment with its name, description, pricing, discount, and optional medicines.")]
    [EndpointName("CreateTreatment")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Create(CreateTreatmentCommand command, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpDelete("{treatmentId:guid}")]
    [ProducesResponseType(typeof(Updated), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Deletes a treatment.")]
    [EndpointDescription("Deletes the treatment with the specified treatment ID.")]
    [EndpointName("DeleteTreatment")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Delete(Guid treatmentId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteTreatmentCommand(treatmentId), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagenatedList<TreatmentDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Lists treatments.")]
    [EndpointDescription("Returns the paginated list of treatments.")]
    [EndpointName("GetTreatments")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetList(CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetTreatmentsQuery(), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpGet("{treatmentId:guid}")]
    [ProducesResponseType(typeof(TreatmentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Gets a treatment by ID.")]
    [EndpointDescription("Returns the treatment with the specified treatment ID.")]
    [EndpointName("GetTreatment")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Get(Guid treatmentId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetTreatmentQuery(treatmentId), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(Updated), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Updates a treatment.")]
    [EndpointDescription("Updates the treatment details and associated medicines. The route ID must match the treatment ID in the command.")]
    [EndpointName("UpdateTreatment")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Update(Guid id, UpdateTreatmentCommand command, CancellationToken cancellationToken)
    {
        if (id != command.TreatmentId)
        {
            return Problem([Error.Failure("Treatment.Id", "The Id that provided in the query does not match the one in the request")]);
        }

        var result = await sender.Send(command, cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }
}