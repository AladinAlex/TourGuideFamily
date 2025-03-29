using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using TourGuideFamily.Dal.Settings;
using TourGuideFamily.Domain.Entities;
using TourGuideFamily.Domain.Interfaces;
using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Dal.Repositories;

public class PromoRepository : PgRepository, IPromoRepository
{
    public PromoRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
        dataSourceBuilder.MapComposite<Promo>("promo_type", Translator);
    }

    public async Task<long[]> AddRangeAsync(Promo[] entities, CancellationToken token, IDbTransaction transaction = null)
    {
        var sql = @"
insert into promos (tour_id, image, name, description)
     select tour_id, image, name, description
       from UNNEST(@promos)
  returning id;
";

        using var dataSource = dataSourceBuilder.Build();
        using var connection = await dataSource.OpenConnectionAsync(token);
        var cmd = new CommandDefinition(
            sql,
            new
            {
                promos = entities
            },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token,
            transaction: transaction);
        return (await connection.QueryAsync<long>(cmd))
            .ToArray();
    }

    public async Task<PromoModel[]> GetMainPromo(CancellationToken token)
    {
        var sql = @"
select image
     , name
     , description
  from promos
 where tour_id is null
";

        using var dataSource = dataSourceBuilder.Build();
        using var connection = await dataSource.OpenConnectionAsync(token);
        var cmd = new CommandDefinition(
            sql,
            new { },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);
        return (await connection.QueryAsync<PromoModel>(cmd))
            .ToArray();
    }

    public async Task<PromoTourModel[]> GetByTourId(long tourId, CancellationToken token)
    {
        var sql = @"
select image
     , name
     , description
  from promos
 where tour_id = @tourId
";

        using var dataSource = dataSourceBuilder.Build();
        using var connection = await dataSource.OpenConnectionAsync(token);
        var cmd = new CommandDefinition(
            sql,
            new
            {
                tourId = tourId
            },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);
        return (await connection.QueryAsync<PromoTourModel>(cmd))
            .ToArray();
    }
}