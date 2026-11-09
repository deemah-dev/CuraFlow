using CuraFlow.Application.Features.Tenants.Commands.CreateTenant;
using CuraFlow.Application.Features.Tenants.Commands.DeleteTenant;
using CuraFlow.Application.Features.Tenants.Commands.UpdateTenant;
using CuraFlow.Application.Features.Tenants.Dtos;
using CuraFlow.Application.Features.Tenants.Queries.GetTenantById;
using CuraFlow.Domain.Common.Results;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CuraFlow.Api.Controllers.V1;

[Route("/tenants")]
public class TenantController(ISender sender) : ApiController
{
    [HttpPost]
    [ProducesResponseType(typeof(TenantDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Creates a tenant.")]
    [EndpointDescription("Creates a tenant with the supplied name and identifier.")]
    [EndpointName("CreateTenant")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Create(CreateTenantCommand command, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpDelete("{tenantId:guid}")]
    [ProducesResponseType(typeof(Deleted), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Deletes a tenant.")]
    [EndpointDescription("Deletes the tenant identified in the command.")]
    [EndpointName("DeleteTenant")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Delete(Guid tenantId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteTenantCommand(tenantId), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Updated), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Updates a tenant.")]
    [EndpointDescription("Updates the tenant name and identifier. The route ID must match the tenant ID in the command.")]
    [EndpointName("UpdateTenant")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Update(Guid id, UpdatedTenantCommand command, CancellationToken cancellationToken)
    {
        if (id != command.TenantId)
        {
            return Problem([Error.Failure("Patient.Id", "The Id that provided in the query does not match the one in the request")]);
        }

        var result = await sender.Send(command, cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpGet("{tenantId}")]
    [ProducesResponseType(typeof(TenantDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Gets a tenant by ID.")]
    [EndpointDescription("Returns the tenant with the specified tenant ID.")]
    [EndpointName("GetTenant")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Get(Guid tenantId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetTenantByIdQuery(tenantId), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }
}