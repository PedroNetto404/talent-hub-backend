namespace TalentHub.Domain.Core.Abstractions;

public abstract record EntityId<TId>
    where TId : EntityId<TId>, new()
{
    public Guid Value { get; private set; } = Guid.NewGuid();

    public static implicit operator Guid(EntityId<TId> id) => id.Value;

    public static implicit operator EntityId<TId>(Guid value) => new TId { Value = value };
}