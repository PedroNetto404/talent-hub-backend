using TalentHub.Domain.Core.Events;

namespace TalentHub.Domain.Core.Abstractions;

public interface IAggregateRoot
{
    IReadOnlyCollection<IEvent> Events { get; }

    void RaiseEvent(IEvent @event);

    void ClearEvents();
}