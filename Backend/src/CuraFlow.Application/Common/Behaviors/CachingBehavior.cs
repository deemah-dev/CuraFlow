using CuraFlow.Application.Common.Interfaces;
using CuraFlow.Domain.Common.Results;

using MediatR;

using Microsoft.Extensions.Caching.Hybrid;

namespace CuraFlow.Application.Common.Behaviors;

public class CachingBehavior<TRequest, TResponse>
(HybridCache hybridCache)
: IPipelineBehavior<TRequest, TResponse>
where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is not ICachedQuery cachedQuery)
        {
            return await next(cancellationToken);
        }

        var result = await hybridCache.GetOrCreateAsync<TResponse>(
            cachedQuery.CacheKey,
            _ =>
            new ValueTask<TResponse>((TResponse)(object)null!),
            options: new HybridCacheEntryOptions
            {
                Flags = HybridCacheEntryFlags.DisableUnderlyingData
            },
            cancellationToken: cancellationToken);

        if (result is null)
        {
            result = await next(cancellationToken);

            if (result is IResult res && res.IsSuccess)
            {
                await hybridCache.SetAsync(
                    cachedQuery.CacheKey,
                    result,
                    options: new HybridCacheEntryOptions
                    {
                        Expiration = cachedQuery.Expiration
                    }, tags: cachedQuery.Tags, cancellationToken);
            }
        }

        return result;
    }
}