using System.Data;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace TalentHub.Infra.Data.Connection;

internal sealed class PostgresConnectionProvider
(
    IServiceProvider serviceProvider
) : IDbConnectionProvider
{
    private readonly string _connectionString =
        serviceProvider.GetRequiredKeyedService<string>("ConnectionString");

    public async Task<IDbConnection> CreateOpenConnectionAsync()
    {
        var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();
        return connection;
    }
}
