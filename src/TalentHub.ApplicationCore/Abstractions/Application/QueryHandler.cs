namespace TalentHub.ApplicationCore.Abstractions.Application;

public abstract class QueryHandler<TQuery, TResult>
(
    ICacheService cacheService
)
    : IQueryHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
    where TResult : notnull
{
    public Task<TResult> HandleAsync(TQuery query) =>
        query switch
        {
            ICachedQuery<TResult> cachedQuery =>
                cacheService.GetOrSetAsync
                (
                    cachedQuery.CacheKey,
                    () => HandleQueryAsync(query),
                    cachedQuery.CacheDuration
                ),
            _ => HandleQueryAsync(query)
        };

    protected abstract Task<TResult> HandleQueryAsync(TQuery query);
}