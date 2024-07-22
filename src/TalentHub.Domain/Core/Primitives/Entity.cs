namespace TalentHub.Domain.Core.Primitives;

public abstract record EntityId<TId>
    where TId : EntityId<TId>, new()
{
    public Guid Value { get; private set; } = Guid.NewGuid();

    public static implicit operator Guid(EntityId<TId> id) => id.Value;

    public static implicit operator EntityId<TId>(Guid value) => new TId { Value = value };
}

public abstract class Entity<TEntityId> : IEquatable<Entity<TEntityId>>
    where TEntityId : EntityId<TEntityId>, new()
{
    public TEntityId Identification { get; } = new();

    public bool Equals(Entity<TEntityId>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Identification.Value == other.Identification.Value;
    }

    public override bool Equals(object? obj) =>
        ReferenceEquals(this, obj) || obj is Entity<TEntityId> other && Equals(other);

    public override int GetHashCode() =>
        Identification.Value.GetHashCode() * 397;
    
    public static bool operator ==(Entity<TEntityId>? left, Entity<TEntityId>? right) =>
        Equals(left, right);
    
    public static bool operator !=(Entity<TEntityId>? left, Entity<TEntityId>? right) =>
        !(left == right);
}