using Dapper;
using Microsoft.Extensions.Options;
using TourGuideFamily.Dal.Settings;
using TourGuideFamily.Domain.Entities;
using TourGuideFamily.Domain.Interfaces;
using TourGuideFamily.Domain.Models;
using static Dapper.SqlMapper;

namespace TourGuideFamily.Dal.Repositories;

public class ReviewRepository : PgRepository, IReviewRepository
{
    public ReviewRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
        dataSourceBuilder.MapComposite<Review>("review_type", Translator);
    }

    public async Task<long> AddAsync(Review entity, CancellationToken token)
    {
        var sql = @"
insert into reviews (firstname, rating, tour_name, description, created_on)
values(@firstname, @rating, @tour_name, @description, @created_on)
  returning id;
";
        using var dataSource = dataSourceBuilder.Build();
        using var connection = await dataSource.OpenConnectionAsync(token);
        var cmd = new CommandDefinition(
            sql,
            new
            {
                firstname = entity.Firstname,
                rating = entity.Rating,
                tour_name = entity.TourName,
                description = entity.Description,
                created_on = entity.CreatedOn
            },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);
        try
        {

            return await connection.QueryFirstAsync<long>(cmd);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<ReviewModel[]> GetAsync(int limit, CancellationToken token)
    {
        var sql = @"
  select firstname
       , rating
       , tour_name
       , description
       , created_on
    from reviews
order by created_on desc
   limit @limit
";
        using var dataSource = dataSourceBuilder.Build();
        using var connection = await dataSource.OpenConnectionAsync(token);
        var cmd = new CommandDefinition(
            sql,
            new
            {
                limit
            },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);
        return (await connection.QueryAsync<ReviewModel>(cmd))
            .ToArray();
    }
}