using Dapper;
using Microsoft.Extensions.Options;
using TourGuideFamily.Dal.Settings;
using TourGuideFamily.Domain.Entities;
using TourGuideFamily.Domain.Interfaces;
using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Dal.Repositories;

public class TourRepository : PgRepository, ITourRepository
{
    public TourRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }

    public async Task<long> AddAsync(Tour entity, CancellationToken token)
    {
        var sql = @"
insert into tours (image, name, description, min_participants, max_participants, price, duration_hour)
     values (@image, @name, @description, @min_participants, @max_participants, @price, @duration_hour)
  returning id;
";

        using var dataSource = dataSourceBuilder.Build();
        using var connection = await dataSource.OpenConnectionAsync(token);
        var cmd = new CommandDefinition(
            sql,
            new
            {
                name = entity.Name,
                description = entity.Description,
                min_participants = entity.MinParticipants,
                max_participants = entity.MaxParticipants,
                price = entity.Price,
                duration_hour = entity.DurationHour,
                image = entity.Image
            },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);
        return await connection.QueryFirstAsync<long>(cmd);
    }

    public async Task<TourInfoModel[]> GetToursInfo(CancellationToken token)
    {
        var sql = @"
   select t.id
        , t.name
        , t.min_participants
        , t.max_participants
        , t.price
        , t.duration_hour
        , count(1) as day_count
     from tours t
left join tour_days d on d.tour_id = t.id
 group by t.id
        , t.name
        , t.min_participants
        , t.max_participants
        , t.price
        , t.duration_hour
";
        using var dataSource = dataSourceBuilder.Build();
        using var connection = await dataSource.OpenConnectionAsync(token);
        var cmd = new CommandDefinition(
            sql,
            new { },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);
        return (await connection.QueryAsync<TourInfoModel>(cmd))
            .ToArray();
    }

    public async Task<TourModel> GetById(long tourId, CancellationToken token)
    {
        var sql = @"
select t.name
     , image
     , description
     , t.min_participants
     , t.max_participants
     , t.price
     , t.duration_hour
  from tours t
 where t.id = @tourId
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
        return await connection.QueryFirstAsync<TourModel>(cmd);
    }
}
