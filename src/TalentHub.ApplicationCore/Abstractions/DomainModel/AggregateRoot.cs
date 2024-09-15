namespace TalentHub.ApplicationCore.Abstractions.DomainModel;

public class AggregateRoot : 
    Entity,
    IAggregateRoot
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyList<IDomainEvent> DomainEvents =>
        _domainEvents.ToList().AsReadOnly();

    public void ClearDomainEvents() =>
        _domainEvents.Clear();

    public void AddDomainEvent(IDomainEvent domainEvent) =>
        _domainEvents.Add(domainEvent);
}
