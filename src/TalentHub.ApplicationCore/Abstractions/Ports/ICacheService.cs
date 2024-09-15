namespace TalentHub.ApplicationCore.Abstractions;

public interface ICacheService
{
    Task<T> GetOrSetAsync<T>
    (
        string key,
        Func<Task<T>> asyncFactory,
        TimeSpan? expirationTime = null
    );

    T GetOrSet<T>
    (
        string key,
        Func<T> factory,
        TimeSpan? expirationTime = null
    );
}
