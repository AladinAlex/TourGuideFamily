using Npgsql.NameTranslation;
using Npgsql;
using TourGuideFamily.Domain.Interfaces;
using TourGuideFamily.Dal.Settings;
using System.Transactions;

namespace TourGuideFamily.Dal.Repositories;

public class PgRepository : IPgRepository
{
    protected static readonly INpgsqlNameTranslator Translator = new NpgsqlSnakeCaseNameTranslator();
    protected NpgsqlDataSourceBuilder dataSourceBuilder;
    protected const int DefaultTimeoutInSeconds = 5;
    public PgRepository(DalOptions dalSettings)
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        dataSourceBuilder = new NpgsqlDataSourceBuilder(dalSettings.PostgresConnectionString);
    }

    public TransactionScope CreateTransactionScope(
    IsolationLevel level = IsolationLevel.ReadCommitted)
    {
        return new TransactionScope(
            TransactionScopeOption.Required,
            new TransactionOptions
            {
                IsolationLevel = level,
                Timeout = TimeSpan.FromSeconds(5)
            },
            TransactionScopeAsyncFlowOption.Enabled);
    }
}