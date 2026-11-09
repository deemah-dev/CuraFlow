using CuraFlow.Application.Common.Interfaces;
using CuraFlow.Application.Features.Tenants.Dtos;
using CuraFlow.Domain.Common.Results;

using MediatR;

namespace CuraFlow.Application.Common.Behaviors;

public class TenantAuthorizationBehavior<TRequest, TResponse>(ITenantContext tenantContext)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is ISkipTenantValidation)
        {
            return await next(cancellationToken);
        }

        if (tenantContext.CurrentTenantId == Guid.Empty || !tenantContext.IsActive)
        {
            return (TResponse)(object)Result.Failure<object>(Error.Failure("Invalid or inactive tenant context."));
        }

        return await next(cancellationToken);
    }
}