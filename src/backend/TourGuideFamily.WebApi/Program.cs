using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using TourGuideFamily.Bll;
using TourGuideFamily.Dal.Extensions;
using TourGuideFamily.WebApi.Middlewares;
using TourGuideFamily.WebApi.Models;
using Logger;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSeriLogging();
var services = builder.Services;

//services.Configure<CorsSetting>(builder.Configuration.GetSection(nameof(CorsSetting)));

CorsSetting corsSetting = new();
builder.Configuration.GetSection(nameof(CorsSetting)).Bind(corsSetting);
//var corsSetting = builder.Configuration.GetSection(nameof(CorsSetting)).Get<CorsSetting>();
services.AddControllers();
services
    .AddOpenApi()
    .AddLogging()
    .AddDalInfrastructure(builder.Configuration)
    .AddDalRepositories()
    .AddServices(builder.Configuration)
    .AddCors(options =>
    {
        options.AddPolicy("VuePolicy", builder =>
        {
            builder
            .WithOrigins(corsSetting.Urls)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        });
    });

services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.UseSwaggerUi();
}

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {
        var result = new
        {
            Status = report.Status.ToString(),
            Checks = report.Entries.Select(e => new
            {
                Name = e.Key,
                Status = e.Value.Status.ToString(),
                Description = e.Value.Description
            }),
            Duration = report.TotalDuration
        };

        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(result);
    }
});

app.UseMiddleware<GrpcExceptionMiddleware>();

app.UseCors("VuePolicy");
//app.UseHttpsRedirection();
//app.UseAuthorization();
app.MapControllers();
//app.MigrateDown();

app.MigrateUp();

app.Run();
