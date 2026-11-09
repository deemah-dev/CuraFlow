using CuraFlow.Application.Common.Interfaces;
using CuraFlow.Application.Features.Tenants.Dtos;
using CuraFlow.Application.Features.Tenants.Queries.GetTenantByIdentifier;
using CuraFlow.Domain.Common.Results;
using CuraFlow.Infrastructure.Tenancy;

using MediatR;

namespace CuraFlow.Api.Middlewares;

public class TenantMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(
        HttpContext context,
        ISender sender,
        ITenantContext tenantContext)
    {
        var host = context.Request.Host.Host;
        var subdomain = host?.Split('.')[0];

        if (string.IsNullOrEmpty(subdomain))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("Subdomain is missing.");
            return;
        }

        var result = await sender.Send(new GetTenantByIdentifierQuery(subdomain));

        if (result.IsError || result.Value is null)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsync("Tenant not found or inactive.");
            return;
        }

        if (tenantContext is TenantContext concreteContext)
        {
            concreteContext.SetTenant(result.Value.TenantId, result.Value.Identifier, result.Value.IsActive);
        }

        await next(context);
    }
}