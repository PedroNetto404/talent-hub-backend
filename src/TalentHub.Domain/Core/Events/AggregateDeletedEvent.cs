using TalentHub.Domain.Core.Abstractions;

namespace TalentHub.Domain.Core.Events;

public record AggregateDeletedEvent<TEntityId>(TEntityId Id)
    : IEvent
    where TEntityId : EntityId<TEntityId>, new();