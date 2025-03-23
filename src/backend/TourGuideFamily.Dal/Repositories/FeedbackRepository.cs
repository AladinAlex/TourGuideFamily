using Dapper;
using Microsoft.Extensions.Options;
using TourGuideFamily.Dal.Settings;
using TourGuideFamily.Domain.Entities;
using TourGuideFamily.Domain.Interfaces;
using TourGuideFamily.Domain.Models;

namespace TourGuideFamily.Dal.Repositories;

public class FeedbackRepository : PgRepository, IFeedbackRepository
{
    public FeedbackRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }

    public async Task<long> AddAsync(CreateFeedbackModel entity, CancellationToken token)
    {
        var sql = @"
insert into feedback (firstname, phone_number, contact_method, tour_id, created_on)
values(@firstname, @phone_number, @contact_method, @tour_id, @created_on)
  returning id;
";
        using var dataSource = dataSourceBuilder.Build();
        using var connection = await dataSource.OpenConnectionAsync(token);

        var cmd = new CommandDefinition(
            sql,
            new
            {
                firstname = entity.Firstname,
                phone_number = entity.PhoneNumber,
                contact_method = entity.ContactMethod,
                tour_id = entity.TourId,
                created_on = entity.CreatedOn,
            },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);
        return await connection.QueryFirstAsync<long>(cmd);
    }
}