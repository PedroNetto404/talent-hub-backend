namespace TalentHub.ApplicationCore.Shared.Results;

public sealed record Error(string Code, string Message)
{
    internal static Error Combine(IEnumerable<Error> errors)
    {
        var enumerable = errors as Error[] ?? errors.ToArray();
        return new Error(
            string.Join(", ", enumerable.Select(e => e.Code)),
            string.Join(", ", enumerable.Select(e => e.Message))
        );
    }
}
