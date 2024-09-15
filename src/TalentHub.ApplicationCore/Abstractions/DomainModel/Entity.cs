using System;

namespace TalentHub.ApplicationCore.Abstractions.DomainModel;

public abstract class Entity : IEquatable<Entity>, IEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    protected Entity() { }

    protected Entity(Guid id) => Id = id;

    public bool Equals(Entity? other) =>
        other is not null && Id == other.Id;

    public override bool Equals(object? obj) =>
        obj is Entity other && Equals(other);

    public override int GetHashCode() =>
        Id.GetHashCode() * 31;

    public override string ToString() =>
        $"{GetType().Name}({Id})";

    public static bool operator ==(Entity? left, Entity? right) =>
        left?.Equals(right) ?? right is null;

    public static bool operator !=(Entity? left, Entity? right) =>
        !(left == right);
}

public interface IEntity
{
    Guid Id { get; }
}