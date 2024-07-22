using TalentHub.Domain.Core.Abstractions;

namespace TalentHub.Domain.Core.Events;

public record AggregateModifiedEvent(IAggregateRoot RootState) : IEvent;