using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TourGuideFamily.Dal.Infrastructure;
using TourGuideFamily.Dal.Repositories;
using TourGuideFamily.Dal.Settings;
using TourGuideFamily.Domain.Interfaces;

namespace TourGuideFamily.Dal.Extensions;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddDalRepositories(
    this IServiceCollection services)
    {
        AddPostgresRepositories(services);

        return services;
    }
    private static void AddPostgresRepositories(IServiceCollection services)
    {
        services.AddScoped<IFeedbackRepository, FeedbackRepository>();
        services.AddScoped<IGuideRepository, GuideRepository>();
        services.AddScoped<IInclusionRepository, InclusionRepository>();
        services.AddScoped<IPromoRepository, PromoRepository>();
        services.AddScoped<ITourDayRepository, TourDayRepository>();
        services.AddScoped<ITourRepository, TourRepository>();
    }

    public static IServiceCollection AddDalInfrastructure(
    this IServiceCollection services,
    IConfiguration config)
    {
        //read config
        services.Configure<DalOptions>(config.GetSection(nameof(DalOptions)));

        //configure postrges types
        Postgres.DapperDefaultTypeMap();

        //add migrations
        Postgres.AddMigrations(services);

        return services;

    }
}