using Dapper;
using Microsoft.Extensions.Options;
using TourGuideFamily.Dal.Settings;
using TourGuideFamily.Domain.Entities;
using TourGuideFamily.Domain.Interfaces;
using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Dal.Repositories;

public class TourDayRepository : PgRepository, ITourDayRepository
{
    public TourDayRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
        dataSourceBuilder.MapComposite<TourDay>("tour_day_type", Translator);
    }

    public async Task<long[]> AddRangeAsync(TourDay[] entities, CancellationToken token)
    {
        var sql = @"
insert into tour_days (tour_id, number, image, name, description)
     select tour_id, number, image, name, description
       from UNNEST(@days)
  returning id;
";

        using var dataSource = dataSourceBuilder.Build();
        using var connection = await dataSource.OpenConnectionAsync(token);
        var cmd = new CommandDefinition(
            sql,
            new
            {
                days = entities
            },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);
        return (await connection.QueryAsync<long>(cmd))
            .ToArray();
    }

    public async Task<TourDayModel[]> GetByTourId(long tourId, CancellationToken token)
    {
        var sql = @"
  select number
       , image
       , name
       , description
    from tour_days
   where tour_id = @tourId
order by number asc
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
        return (await connection.QueryAsync<TourDayModel>(cmd))
            .ToArray();
    }
}