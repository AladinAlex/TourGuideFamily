using Microsoft.Extensions.DependencyInjection;
using TourGuideFamily.Bll.Services;
using TourGuideFamily.Bll.Services.Interfaces;

namespace TourGuideFamily.Bll;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<ICreateService, CreateService>()
                .AddScoped<IFeedbackService, FeedbackService>()
                .AddScoped<IGetTourService, GetTourService>()
                .AddScoped<IMultimediaService, MultimediaService>()
                .AddScoped<IDateTimeService, DateTimeService>()
                .AddScoped<IUrlCoderService, UrlCoderService>();
    }
}