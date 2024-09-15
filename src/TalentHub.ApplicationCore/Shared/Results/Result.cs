namespace TalentHub.ApplicationCore.Shared.Results;

public class Result
{
    private readonly Error? _error;

    public bool IsSuccess => _error is null;

    public bool IsFailure => !IsSuccess;

    public Error Error =>
        IsFailure
            ? _error!
            : throw new InvalidOperationException("There is no error for successful result.");

    protected Result()
    {
    }

    protected Result(Error error) => _error = error;

    public static Result Ok() => new();
    public static Result<T> Ok<T>(T value) => new(value);
    public static Result Fail(Error error) => new(error);
    public static Result<T> Fail<T>(Error error) => new(error);

    public static implicit operator Result(Error error) => new(error);
}

public class Result<T> : Result
{
    protected internal Result(T value) => _value = value;
    protected internal Result(Error error) : base(error) {}
    private readonly T? _value;

    public T Value =>
        IsSuccess
            ? _value!
            : throw new InvalidOperationException("There is no value for failed result.");

    public static implicit operator Result<T>(T value) => Ok(value);
    public static implicit operator Result<T>(Error error) => Fail<T>(error);
}