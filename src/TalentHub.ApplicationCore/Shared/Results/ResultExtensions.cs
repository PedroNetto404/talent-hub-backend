using TalentHub.ApplicationCore.Shared.Results;

namespace TalentHub.ApplicationCore.Results;

public static class ResultExtensions
{
    public async static Task<TOutput> MatchAsync<TInput, TOutput>
    (
        this Task<Result<TInput>> resultTask,
        Func<TInput, Task<TOutput>> onSuccess,
        Func<Error, Task<TOutput>> onFailure
    )
    {
        var result = await resultTask;

        return result.IsSuccess
            ? await onSuccess(result.Value)
            : await onFailure(result.Error);
    }
}