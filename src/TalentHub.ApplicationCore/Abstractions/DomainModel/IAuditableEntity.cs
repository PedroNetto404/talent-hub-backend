namespace TalentHub.ApplicationCore.Abstractions.DomainModel;

public interface IAuditableEntity : IEntity
{
    DateTime CreatedAt { get; }
    DateTime? UpdatedAt { get; protected set; }
    DateTime? DeletedAt { get; protected set; }
    public void OnUpdate() => UpdatedAt = DateTime.UtcNow;
    public void OnDelete() => DeletedAt = DateTime.UtcNow;
    public bool Deleted => DeletedAt.HasValue;
    public bool Updated => UpdatedAt.HasValue;
}