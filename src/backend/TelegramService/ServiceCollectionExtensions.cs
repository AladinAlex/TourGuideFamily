using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TelegramService.Settings;

namespace TelegramService;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTelegramService(this IServiceCollection serviceCollection, IConfiguration config)
    {
        serviceCollection.Configure<Telegram>(config.GetSection(nameof(Telegram)));

        return serviceCollection
                .AddScoped<ITelegramApiService>(x => new TelegramApiService(config["Telegram:Api"], config["Telegram:Token"]));
    }
}
