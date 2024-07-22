namespace TalentHub.Domain.Core.Abstractions;

public interface IEntity<out TEntityId>
    where TEntityId : EntityId<TEntityId>, new()
{
    TEntityId Identification { get; }
}