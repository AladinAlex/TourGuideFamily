using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Logger;

public static class SerilogExtensions
{
    public static IHostBuilder UseSeriLogging(this IHostBuilder hostBuilder)
    {
        return hostBuilder.UseSerilog((context, services, config) =>
        {
            config.MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning);

            config.WriteTo.Console(
                outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}");

            config.WriteTo.File(
                path: "logs/log-.log",
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 7,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}");
        });
    }
}