using TalentHub.ApplicationCore.Results;
using TalentHub.ApplicationCore.Shared.Results;

namespace TalentHub.ApplicationCore.Abstractions.Application;

public interface IUseCaseHandler<in TUseCase> where TUseCase : IUseCase
{
    Task<Result> ExecuteAsync(TUseCase useCase);
}

public interface IUseCaseHandler<in TUseCase, TOutput> where TUseCase : IUseCase<TOutput>
{
    Task<Result<TOutput>> ExecuteAsync(TUseCase useCase);
}