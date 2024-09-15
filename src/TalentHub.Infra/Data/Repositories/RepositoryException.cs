namespace TalentHub.Infra.Data.Repositories;

public sealed class RepositoryException(Exception innerException) :
    Exception("An error occurred while executing a repository operation.", innerException);