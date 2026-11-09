using CuraFlow.Application.Common.Models;
using CuraFlow.Application.Features.Medicines.Commands.CreateMedicine;
using CuraFlow.Application.Features.Medicines.Commands.DeleteMedicine;
using CuraFlow.Application.Features.Medicines.Commands.UpdateMedicine;
using CuraFlow.Application.Features.Medicines.Dtos;
using CuraFlow.Application.Features.Medicines.Queries.GetMedicine;
using CuraFlow.Application.Features.Medicines.Queries.GetMedicines;
using CuraFlow.Domain.Common.Results;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CuraFlow.Api.Controllers.V1;

[Route("/medicines")]
public class MedicineController(ISender sender) : ApiController
{
    [HttpPost]
    [ProducesResponseType(typeof(MedicineDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Creates a medicine.")]
    [EndpointDescription("Creates a medicine with the supplied name and price.")]
    [EndpointName("CreateMedicine")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Create(CreateMedicineCommand command, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpDelete("{medicineId:guid}")]
    [ProducesResponseType(typeof(Deleted), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Deletes a medicine.")]
    [EndpointDescription("Deletes the medicine with the specified ID.")]
    [EndpointName("DeleteMedicine")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Delete(Guid medicineId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteMedicineCommand(medicineId), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagenatedList<MedicineDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Lists medicines.")]
    [EndpointDescription("Returns the paginated list of medicines.")]
    [EndpointName("GetMedicines")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetList(CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetMedicinesQuery(), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpGet("{medicineId:guid}")]
    [ProducesResponseType(typeof(MedicineDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Gets a medicine by ID.")]
    [EndpointDescription("Returns the medicine with the specified ID.")]
    [EndpointName("GetMedicine")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Get(Guid medicineId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetMedicineQuery(medicineId), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(Updated), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Updates a medicine.")]
    [EndpointDescription("Updates the medicine name and price. The route ID must match the medicine ID in the command.")]
    [EndpointName("UpdateMedicine")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Update(Guid id, UpdateMedicineCommand command, CancellationToken cancellationToken)
    {
        if (id != command.MedicineId)
        {
            return Problem([Error.Failure("MedicalRecord.Id", "The Id that provided in the query does not match the one in the request")]);
        }

        var result = await sender.Send(command, cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }
}