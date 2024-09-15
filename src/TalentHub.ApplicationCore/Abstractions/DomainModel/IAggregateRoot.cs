namespace TalentHub.ApplicationCore.Abstractions.DomainModel;

public interface IAggregateRoot
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }

    void ClearDomainEvents();

    void AddDomainEvent(IDomainEvent domainEvent);
}