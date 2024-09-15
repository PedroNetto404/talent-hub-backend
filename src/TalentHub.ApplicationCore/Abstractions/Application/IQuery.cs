namespace TalentHub.ApplicationCore.Abstractions.Application;

public interface IQuery<TResult> where TResult : notnull;

public interface ICachedQuery<TResult> : IQuery<TResult> where TResult : notnull
{
    TimeSpan CacheDuration { get; }
    public string CacheKey { get; }
}