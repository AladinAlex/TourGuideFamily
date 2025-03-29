using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using TourGuideFamily.Dal.Settings;
using TourGuideFamily.Domain.Entities;
using TourGuideFamily.Domain.Interfaces;
using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Dal.Repositories;

public class InclusionRepository : PgRepository, IInclusionRepository
{
    public InclusionRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
        dataSourceBuilder.MapComposite<Inclusion>("inclusion_type", Translator);
    }

    public async Task<long[]> AddRangeAsync(Inclusion[] entities, CancellationToken token, IDbTransaction transaction)
    {
        var sql = @"
insert into inclusions (tour_id, description, include)
     select tour_id, description, include
       from UNNEST(@inclusions)
  returning id;
";

        using var dataSource = dataSourceBuilder.Build();
        using var connection = await dataSource.OpenConnectionAsync(token);
        var cmd = new CommandDefinition(
            sql,
            new
            {
                inclusions = entities
            },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token,
            transaction: transaction);
        return (await connection.QueryAsync<long>(cmd))
            .ToArray();
    }

    public async Task<InclusionModel[]> GetByTourId(long tourId, CancellationToken token)
    {
        var sql = @"
select description
     , include
  from inclusions
 where tour_id = @tourId
";
        using var dataSource = dataSourceBuilder.Build();
        using var connection = await dataSource.OpenConnectionAsync(token);
        var cmd = new CommandDefinition(
            sql,
            new
            {
                tourId = tourId,
            },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);
        return (await connection.QueryAsync<InclusionModel>(cmd))
            .ToArray();
    }
}