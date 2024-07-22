namespace TalentHub.Domain.Core.Primitives;

public record AggregateDeletedEvent<TEntityId>(TEntityId Id)
    : IEvent
    where TEntityId : EntityId<TEntityId>, new();

public record AggregateModifiedEvent(IAggregateRoot RootState) : IEvent;

public interface IAggregateRoot
{
    IReadOnlyCollection<IEvent> Events { get; }

    void RaiseEvent(IEvent @event);

    void ClearEvents();
}

public abstract class AggregateRoot<TEntityId>
    : Entity<TEntityId>, IAggregateRoot
    where TEntityId : EntityId<TEntityId>, new()
{
    private readonly List<IEvent> _events = [];

    public IReadOnlyCollection<IEvent> Events => _events.AsReadOnly();

    public void ClearEvents() => _events.Clear();

    public void RaiseEvent(IEvent @event) => _events.Add(@event);
}

