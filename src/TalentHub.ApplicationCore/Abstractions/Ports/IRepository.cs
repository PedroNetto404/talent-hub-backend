using System.Linq.Expressions;
using TalentHub.ApplicationCore.Abstractions.DomainModel;
using TalentHub.ApplicationCore.Shared;

namespace TalentHub.ApplicationCore.Abstractions.Ports;

public interface IRepository<T>
    where T : IAggregateRoot
{
    Task<T?> GetByIdAsync(Guid id);

    Task<ListPage<T>> GetPageAsync
    (
        int page,
        int pageSize,
        Expression<Func<T, bool>> predicate
    );

    Task AddAsync(T aggregateRoot);

    Task UpdateAsync(T aggregateRoot);

    Task DeleteAsync(T aggregateRoot);
}