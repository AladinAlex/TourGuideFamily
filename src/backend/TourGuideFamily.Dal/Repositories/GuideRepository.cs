using Dapper;
using Microsoft.Extensions.Options;
using TourGuideFamily.Dal.Settings;
using TourGuideFamily.Domain.Entities;
using TourGuideFamily.Domain.Interfaces;
using TourGuideFamily.Domain.Models;
using static Dapper.SqlMapper;

namespace TourGuideFamily.Dal.Repositories;

public class GuideRepository : PgRepository, IGuideRepository
{
    public GuideRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }

    public async Task<long> AddAsync(CreateGuide entity, CancellationToken token)
    {
        var sql = @"
insert into guides(image, firstname, surname, description)
values(@image, @firstname, @surname, @description)
  returning id;
";

        using var dataSource = dataSourceBuilder.Build();
        using var connection = await dataSource.OpenConnectionAsync(token);
        var cmd = new CommandDefinition(
        sql,
            new
            {
                image = entity.Image,
                firstname = entity.Firstname,
                surname = entity.Surname,
                description = entity.Description,
            },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);
        return await connection.QueryFirstAsync<long>(cmd);
    }

    public async Task<GuideModel[]> GetAllAsync(CancellationToken token)
    {
        var sql = @"
select image
     , firstname
     , surname
     , description
  from guides
";
        using var dataSource = dataSourceBuilder.Build();
        using var connection = await dataSource.OpenConnectionAsync(token);
        var cmd = new CommandDefinition(
            sql,
            new {},
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);
        return (await connection.QueryAsync<GuideModel>(cmd))
            .ToArray();

    }
}