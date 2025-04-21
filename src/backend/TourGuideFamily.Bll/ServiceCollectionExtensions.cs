using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using Storage.GrpcContracts.Api;
using TelegramService;
using TourGuideFamily.Bll.Services;
using TourGuideFamily.Bll.Services.Interfaces;

namespace TourGuideFamily.Bll;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddGrpcClient<UploadFileService.UploadFileServiceClient>(options =>
            {
                options.Address = new Uri(configuration["Grpc:StorageUrl"]!);
            })
            .AddPolicyHandler(Policy<HttpResponseMessage>
                .Handle<RpcException>(ex => ex.StatusCode == StatusCode.Unavailable || ex.StatusCode == StatusCode.DeadlineExceeded)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
            )
            .ConfigureChannel(o =>
            {
                // Настройки канала gRPC
                o.UnsafeUseInsecureChannelCallCredentials = true; // Для HTTP без TLS
                o.HttpHandler = new SocketsHttpHandler
                {
                    PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
                    KeepAlivePingDelay = TimeSpan.FromSeconds(60),
                    KeepAlivePingTimeout = TimeSpan.FromSeconds(30)
                };
                #if DEBUG
                o.LoggerFactory = LoggerFactory.Create(logging =>
                {
                    logging.AddConsole();
                    logging.SetMinimumLevel(LogLevel.Trace);
                });
                #endif
            });
        return serviceCollection
                .AddTelegramService(configuration)
                .AddScoped<ICreateService, CreateService>()
                .AddScoped<IFeedbackService, FeedbackService>()
                .AddScoped<IGetTourService, GetTourService>()
                .AddScoped<IMultimediaService, MultimediaService>()
                .AddScoped<IDateTimeService, DateTimeService>()
                .AddScoped<IUrlCoderService, UrlCoderService>();
    }
}