using System.Data;

namespace TalentHub.Infra.Data.Connection;

internal interface IDbConnectionProvider
{
    Task<IDbConnection> CreateOpenConnectionAsync();
}
