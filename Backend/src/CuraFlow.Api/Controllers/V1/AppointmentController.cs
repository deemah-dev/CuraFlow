using CuraFlow.Application.Common.Models;
using CuraFlow.Application.Features.Appointments.Commands.CreateAppointmet;
using CuraFlow.Application.Features.Appointments.Commands.DeleteAppointment;
using CuraFlow.Application.Features.Appointments.Commands.ScheduleAppointmet;
using CuraFlow.Application.Features.Appointments.Commands.UpdateAppointmentStatus;
using CuraFlow.Application.Features.Appointments.Dtos;
using CuraFlow.Application.Features.Appointments.Queries.GetAppointment;
using CuraFlow.Application.Features.Appointments.Queries.GetAppointments;
using CuraFlow.Domain.Common.Results;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CuraFlow.Api.Controllers.V1;

[Route("/appointments")]
public class AppointmentController(ISender sender) : ApiController
{
    [HttpPost]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Creates an appointment.")]
    [EndpointDescription("Creates an appointment for a patient with a doctor in a medical department at the specified date and time.")]
    [EndpointName("CreateAppointment")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Create(CreateAppointmentCommand command, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);

        return result.Match(Response => Ok((AppointmentDto)Response), Problem);
    }

    [HttpGet("{appointmentId:guid}")]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Gets an appointment by ID.")]
    [EndpointDescription("Returns the appointment with the specified appointment ID.")]
    [EndpointName("GetAppointment")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Get(Guid appointmentId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetAppointmentQuery(appointmentId), cancellationToken);

        return result.Match(Response => Ok(Response), Problem);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagenatedList<AppointmentDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Lists appointments.")]
    [EndpointDescription("Returns a paginated, filterable, and sortable list of appointments matching the supplied query parameters.")]
    [EndpointName("GetAppointments")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Get([FromQuery] GetAppointmentsQuery query, CancellationToken cancellationToken)
    {
        var result = await sender.Send(query, cancellationToken);

        return result.Match(Response => Ok(Response), Problem);
    }

    [HttpPatch("schedule/{id:guid}")]
    [ProducesResponseType(typeof(Updated), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Reschedules an appointment.")]
    [EndpointDescription("Changes the appointment date and time. The route ID must match the appointment ID in the command.")]
    [EndpointName("ScheduleAppointment")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Schedule(Guid id, ScheduleAppointmentCommand command, CancellationToken cancellationToken)
    {
        if (id != command.AppointmentId)
        {
            return Problem([Error.Failure("Appointment.Id", "The Id that provided in the query does not match the one in the request")]);
        }

        var result = await sender.Send(command, cancellationToken);

        return result.Match(Response => Ok(Response), Problem);
    }

    [HttpPatch("update-status/{id:guid}")]
    [ProducesResponseType(typeof(Updated), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Updates an appointment's status.")]
    [EndpointDescription("Changes the appointment status. The route ID must match the appointment ID in the command.")]
    [EndpointName("UpdateAppointmentStatus")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> UpdateStatus(Guid id, UpdateAppointmentStatusCommand command, CancellationToken cancellationToken)
    {
        if (id != command.AppointmentId)
        {
            return Problem([Error.Failure("Appointment.Id", "The Id that provided in the query does not match the one in the request")]);
        }

        var result = await sender.Send(command, cancellationToken);

        return result.Match(Response => Ok(Response), Problem);
    }

    [HttpDelete("{appointmentId:guid}")]
    [ProducesResponseType(typeof(Deleted), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Deletes an appointment.")]
    [EndpointDescription("Deletes the appointment with the specified appointment ID.")]
    [EndpointName("DeleteAppointment")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Delete(Guid appointmentId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteAppointmentCommand(appointmentId), cancellationToken);

        return result.Match(Response => Ok(Response), Problem);
    }
}