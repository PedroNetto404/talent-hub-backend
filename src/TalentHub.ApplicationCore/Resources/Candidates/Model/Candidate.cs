using TalentHub.ApplicationCore.Abstractions.DomainModel;

namespace TalentHub.ApplicationCore.Resources.Candidates.Model;

public sealed class Candidate : AggregateRoot
{
    public string FirstName { get; private set; }
}