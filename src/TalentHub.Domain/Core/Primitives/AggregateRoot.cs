using TalentHub.Domain.Core.Abstractions;
using TalentHub.Domain.Core.Events;

namespace TalentHub.Domain.Core.Primitives;

public abstract class AggregateRoot<TEntityId>
    : Entity<TEntityId>, IAggregateRoot
    where TEntityId : EntityId<TEntityId>, new()
{
    private readonly List<IEvent> _events = [];

    public IReadOnlyCollection<IEvent> Events => _events.AsReadOnly();

    public void ClearEvents() => _events.Clear();

    public void RaiseEvent(IEvent @event) => _events.Add(@event);
}

