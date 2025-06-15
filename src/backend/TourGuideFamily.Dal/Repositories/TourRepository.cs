using System.Data;
using System.Text;
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

    public async Task<long> AddAsync(Tour entity, CancellationToken token, IDbTransaction transaction)
    {
        var sql = @"
insert into tours (image, name, min_participants, max_participants, price, duration_hour_min, duration_hour_max, slug, description, description_image, sort_order)
     values (@image, @name, @min_participants, @max_participants, @price, @duration_hour_min, @duration_hour_max, @slug, @description, @description_image, @sort_order)
  returning id;
";

        using var dataSource = dataSourceBuilder.Build();
        using var connection = await dataSource.OpenConnectionAsync(token);
        var cmd = new CommandDefinition(
            sql,
            new
            {
                name = entity.Name,
                min_participants = entity.MinParticipants,
                max_participants = entity.MaxParticipants,
                price = entity.Price,
                duration_hour_min = entity.DurationHourMin,
                duration_hour_max = entity.DurationHourMax,
                image = entity.Image,
                slug = entity.Slug,
                description = entity.Description,
                description_image = entity.DescriptionImage,
                sort_order = entity.SortOrder,
            },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token,
            transaction: transaction);
        return await connection.QueryFirstAsync<long>(cmd);
    }

    public async Task<TourInfoModel[]> GetToursInfo(CancellationToken token)
    {
        var sql = @"
   select t.name
        , t.image
        , t.min_participants
        , t.max_participants
        , t.price
        , t.duration_hour_min
        , t.duration_hour_max
        , t.slug
        , count(1) as day_count
     from tours t
left join tour_days d on d.tour_id = t.id
 group by t.name
        , t.image
        , t.min_participants
        , t.max_participants
        , t.price
        , t.duration_hour_min
        , t.duration_hour_max
        , t.slug
        , t.sort_order
 order by t.sort_order
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
     , t.min_participants
     , t.max_participants
     , t.price
     , t.duration_hour_min
     , t.duration_hour_max
     , t.description
     , t.description_image
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

    public async Task<int> GetCountBySlug(string slug, CancellationToken token)
    {
        var sql = @"
select count(1)
  from tours t
 where t.slug = @slug
";
        using var dataSource = dataSourceBuilder.Build();
        using var connection = await dataSource.OpenConnectionAsync(token);
        var cmd = new CommandDefinition(
            sql,
            new
            {
                slug = slug,
            },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);
        return await connection.QueryFirstAsync<int>(cmd);
    }

    public async Task<long> GetTourIdBySlug(string slug, CancellationToken token)
    {
        var sql = @"
select t.id
  from tours t
 where t.slug = @slug
";
        using var dataSource = dataSourceBuilder.Build();
        using var connection = await dataSource.OpenConnectionAsync(token);
        var cmd = new CommandDefinition(
            sql,
            new
            {
                slug = slug,
            },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);
        return await connection.QueryFirstAsync<long>(cmd);
    }

    public async Task<TourLinkModel[]> GetTourLink(int? limit, CancellationToken token)
    {
        var sql = new StringBuilder(@"
  select name
       , slug
    from tours
order by sort_order asc
");

        var @params = new DynamicParameters();
        if(limit.HasValue)
        {
            @params.Add("@limit", limit.Value);
            sql.AppendLine("limit @limit");
        }
        using var dataSource = dataSourceBuilder.Build();
        using var connection = await dataSource.OpenConnectionAsync(token);
        var cmd = new CommandDefinition(
            sql.ToString(),
            @params,
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);
        return (await connection.QueryAsync<TourLinkModel>(cmd))
            .ToArray();
    }
}
