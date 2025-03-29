using System.Data;
using Microsoft.Extensions.Options;
using Npgsql;
using TourGuideFamily.Dal.Settings;
using TourGuideFamily.Domain.Interfaces;

namespace TourGuideFamily.Dal.Repositories;

public class PostgresUnitOfWork : IUnitOfWork
{
    private readonly DalOptions _dalOptions;
    private IDbTransaction _transaction;
    private NpgsqlConnection _connection;

    public PostgresUnitOfWork(IOptions<DalOptions> dalSettings)
    {
        _dalOptions = dalSettings.Value;
    }

    public async Task<IDbTransaction> BeginTransactionAsync()
    {
        _connection = new NpgsqlConnection(_dalOptions.PostgresConnectionString);
        await _connection.OpenAsync();
        _transaction = _connection.BeginTransaction();
        return _transaction;
    }

    public async Task CommitAsync()
    {
        _transaction?.Commit();
        await _connection.CloseAsync();
    }

    public async Task RollbackAsync()
    {
        _transaction?.Rollback();
        await _connection.CloseAsync();
    }
}