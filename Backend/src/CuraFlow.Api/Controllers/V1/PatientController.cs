using CuraFlow.Application.Common.Models;
using CuraFlow.Application.Features.Patients.Commands.CreatePatient;
using CuraFlow.Application.Features.Patients.Commands.DeletePatient;
using CuraFlow.Application.Features.Patients.Commands.UpdatePatinet;
using CuraFlow.Application.Features.Patients.Dtos;
using CuraFlow.Application.Features.Patients.Queries.GetPatient;
using CuraFlow.Application.Features.Patients.Queries.GetPatinets;
using CuraFlow.Domain.Common.Results;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CuraFlow.Api.Controllers.V1;

[Route("/patients")]
public class PatientController(ISender sender) : ApiController
{
    [HttpPost]
    [ProducesResponseType(typeof(PatientDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Creates a patient.")]
    [EndpointDescription("Creates a patient using the supplied name and contact details.")]
    [EndpointName("CreatePatient")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Create(CreatePatientCommand command, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpDelete("{patientId:guid}")]
    [ProducesResponseType(typeof(Deleted), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Deletes a patient.")]
    [EndpointDescription("Deletes the patient with the specified patient ID.")]
    [EndpointName("DeletePatient")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Delete(Guid patientId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeletePatientCommand(patientId), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagenatedList<PatientDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Lists patients.")]
    [EndpointDescription("Returns the paginated list of patients.")]
    [EndpointName("GetPatients")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetList(CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetPatinetsQuery(), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpGet("{patientId:guid}")]
    [ProducesResponseType(typeof(PatientDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Gets a patient by ID.")]
    [EndpointDescription("Returns the patient with the specified patient ID.")]
    [EndpointName("GetPatient")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Get(Guid patientId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetPatinetQuery(patientId), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(Updated), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Updates a patient.")]
    [EndpointDescription("Updates the patient details. The route ID must match the patient ID in the command.")]
    [EndpointName("UpdatePatient")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Update(Guid id, UpdatePatientCommand command, CancellationToken cancellationToken)
    {
        if (id != command.PatinetId)
        {
            return Problem([Error.Failure("Patient.Id", "The Id that provided in the query does not match the one in the request")]);
        }

        var result = await sender.Send(command, cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }
}