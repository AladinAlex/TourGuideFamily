using Microsoft.Extensions.DependencyInjection;
using Storage.Bll.Services;
using Storage.Bll.Services.Interfaces;

namespace Storage.Bll;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<IUploadService, UploadService>();
    }
}