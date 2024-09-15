using System.Data;
using Dapper;
using TalentHub.Infra.Data.Connection;

namespace TalentHub.Infra.Data.Repositories;

internal abstract class Repository(IDbConnectionProvider connectionProvider)
{
    static Repository()
    {
        DefaultTypeMap.MatchNamesWithUnderscores = true;
    }

    private const int DefaultCommandTimeout = 15;

    protected async Task<IEnumerable<T>> QueryAsync<T>
    (
        string sql,
        object? param = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null
    ) => await RunOrThrowAsync(async () =>
    {
        using var connection = await connectionProvider.CreateOpenConnectionAsync();
        return await connection.QueryAsync<T>(sql, param, transaction, commandTimeout ?? DefaultCommandTimeout);
    });

    protected async Task<IEnumerable<T1>> QueryAsync<T1, T2>
    (
        string sql,
        Func<T1, T2, T1> map,
        string splitOn,
        object? param = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null
    ) => await RunOrThrowAsync(async () =>
    {
        using var connection = await connectionProvider.CreateOpenConnectionAsync();
        return await connection.QueryAsync
        (
            param: param,
            transaction: transaction,
            commandTimeout: commandTimeout ?? DefaultCommandTimeout,
            sql: sql,
            map: map,
            splitOn: splitOn
        );
    });

    protected async Task<IEnumerable<T1>> QueryAsync<T1, T2, T3>
    (
        string sql,
        Func<T1, T2, T3, T1> map,
        string splitOn,
        object? param = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null
    ) => await RunOrThrowAsync(async () =>
    {
        using var connection = await connectionProvider.CreateOpenConnectionAsync();
        return await connection.QueryAsync
        (
            param: param,
            transaction: transaction,
            commandTimeout: commandTimeout ?? DefaultCommandTimeout,
            sql: sql,
            map: map,
            splitOn: splitOn
        );
    });

    protected async Task<IEnumerable<T1>> QueryAsync<T1, T2, T3, T4>
    (
        string sql,
        Func<T1, T2, T3, T4, T1> map,
        string splitOn,
        object? param = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null
    ) => await RunOrThrowAsync(async () =>
    {
        using var connection = await connectionProvider.CreateOpenConnectionAsync();
        return await connection.QueryAsync
        (
            param: param,
            transaction: transaction,
            commandTimeout: commandTimeout ?? DefaultCommandTimeout,
            sql: sql,
            map: map,
            splitOn: splitOn
        );
    });

    protected async Task<T?> QueryFirstOrDefaultAsync<T>
    (
        string sql,
        object? param = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null
    ) => await RunOrThrowAsync(async () =>
    {
        using var connection = await connectionProvider.CreateOpenConnectionAsync();
        return await connection.QueryFirstOrDefaultAsync<T>
        (
            sql,
            param,
            transaction,
            commandTimeout ?? DefaultCommandTimeout
        );
    });

    protected async Task<T?> QuerySingleOrDefaultAsync<T>
    (
        string sql,
        object? param = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null
    ) => await RunOrThrowAsync(async () =>
    {
        using var connection = await connectionProvider.CreateOpenConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<T>
        (
            sql,
            param,
            transaction,
            commandTimeout ?? DefaultCommandTimeout
        );
    });

    protected async Task<int> ExecuteAsync
    (
        string sql,
        object? param = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null
    ) => await RunOrThrowAsync(async () =>
    {
        using var connection = await connectionProvider.CreateOpenConnectionAsync();
        return await connection.ExecuteAsync(sql, param, transaction, commandTimeout ?? DefaultCommandTimeout);
    });

    protected async Task<T?> ExecuteScalarAsync<T>
    (
        string sql,
        object? param = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null
    ) => await RunOrThrowAsync(async () =>
    {
        using var connection = await connectionProvider.CreateOpenConnectionAsync();
        return await connection.ExecuteScalarAsync<T>(sql, param, transaction, commandTimeout ?? DefaultCommandTimeout);
    });

    private static async Task<T> RunOrThrowAsync<T>(Func<Task<T>> func)
    {
        try
        {
            return await func();
        }
        catch (Exception ex)
        {
            throw new RepositoryException(ex);
        }
    }
}
