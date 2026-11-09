using CuraFlow.Application.Features.Invoices.Commands.CreateInvoice;
using CuraFlow.Application.Features.Invoices.Commands.SettleInvoice;
using CuraFlow.Application.Features.Invoices.Dtos;
using CuraFlow.Application.Features.Invoices.Queries.GetInvoice;
using CuraFlow.Domain.Common.Results;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CuraFlow.Api.Controllers.V1;

[Route("/invoices")]
public class InvoiceController(ISender sender) : ApiController
{
    [HttpGet("{invoiceId:guid}")]
    [ProducesResponseType(typeof(InvoiceDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Gets an invoice by ID.")]
    [EndpointDescription("Returns the invoice and its line items for the specified invoice ID.")]
    [EndpointName("GetInvoice")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Get(Guid invoiceId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetInvoiceQuery(invoiceId), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpPost]
    [ProducesResponseType(typeof(InvoiceDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Creates an invoice.")]
    [EndpointDescription("Creates an invoice for the treatment specified in the request.")]
    [EndpointName("CreateInvoice")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Create(CreateInvoiceCommand command, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpPost("{treatmentId:guid}/settle")]
    [ProducesResponseType(typeof(Success), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Settles an invoice.")]
    [EndpointDescription("Settles the invoice associated with the specified treatment ID.")]
    [EndpointName("SettleInvoice")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Settle(Guid treatmentId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new SettleInvoiceCommand(treatmentId), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }
}