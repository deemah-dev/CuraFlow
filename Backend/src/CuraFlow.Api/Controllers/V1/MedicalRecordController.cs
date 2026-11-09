using CuraFlow.Application.Common.Models;
using CuraFlow.Application.Features.MedicalRecord.Commands.CreateMedicalRecord;
using CuraFlow.Application.Features.MedicalRecord.Commands.DeleteMedicalRecord;
using CuraFlow.Application.Features.MedicalRecord.Commands.UpdateMedicalRecord;
using CuraFlow.Application.Features.MedicalRecord.Dtos;
using CuraFlow.Application.Features.MedicalRecord.Queries.GetMedicalRecord;
using CuraFlow.Application.Features.MedicalRecord.Queries.GetMedicalRecords;
using CuraFlow.Domain.Common.Results;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CuraFlow.Api.Controllers.V1;

[Route("/medical-records")]
public class MedicalRecordController(ISender sender) : ApiController
{
    [HttpPost]
    [ProducesResponseType(typeof(MedicalRecordDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Creates a medical record.")]
    [EndpointDescription("Creates a medical record for the specified patient, including blood type and medical history information.")]
    [EndpointName("CreateMedicalRecord")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Create(CreateMedicalRecordCommand command, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpDelete("{medicalRecordId:guid}")]
    [ProducesResponseType(typeof(Deleted), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Deletes a medical record.")]
    [EndpointDescription("Deletes the medical record with the specified ID.")]
    [EndpointName("DeleteMedicalRecord")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Delete(Guid medicalRecordId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteMedicalRecordCommand(medicalRecordId), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagenatedList<MedicalRecordDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Lists medical records.")]
    [EndpointDescription("Returns the paginated list of medical records.")]
    [EndpointName("GetMedicalRecords")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetList(CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetMedicalRecordsQuery(), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpGet("{medicalRecordId:guid}")]
    [ProducesResponseType(typeof(MedicalRecordDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Gets a medical record by ID.")]
    [EndpointDescription("Returns the medical record with the specified ID.")]
    [EndpointName("GetMedicalRecord")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Get(Guid medicalRecordId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetMediclaRecordQuery(medicalRecordId), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(Updated), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Updates a medical record.")]
    [EndpointDescription("Updates the medical record's blood type and history details. The route ID must match the ID in the command.")]
    [EndpointName("UpdateMedicalRecord")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Update(Guid id, UpdateMedicalRecordCommand command, CancellationToken cancellationToken)
    {
        if (id != command.MedicalRecordId)
        {
            return Problem([Error.Failure("MedicalRecord.Id", "The Id that provided in the query does not match the one in the request")]);
        }

        var result = await sender.Send(command, cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }
}