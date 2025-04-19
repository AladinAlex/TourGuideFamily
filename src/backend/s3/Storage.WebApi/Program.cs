using Storage.WebApi.GrpcServices;
using Storage.Bll;
using Microsoft.Extensions.FileProviders;
using Storage.Bll.Consts;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc(options =>
{
    options.MaxReceiveMessageSize = 1024 * 1024 * 35; // 25 MB
    //interceptors
}).AddJsonTranscoding();

//#if DEBUG
//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.Listen(IPAddress.Any, 5201, listenOptions =>
//    {
//        listenOptions.Protocols = HttpProtocols.Http2;
//        listenOptions.UseHttps("server.pfx", "your-password");
//    });
//});
//#endif

builder.Services.AddGrpcReflection();
builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGrpcReflectionService();
}

var storageFolder = builder.Configuration["StoragePath"]!;
string filesPath = Path.Combine(AppContext.BaseDirectory, storageFolder);
if (!Directory.Exists(filesPath))
{
    Directory.CreateDirectory(filesPath);
}
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(filesPath),
    RequestPath = $"/{storageFolder}",
    ServeUnknownFileTypes = true,
    DefaultContentType = "application/octet-stream"
});
app.MapGrpcService<UploadFileServiceGrpc>();

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

app.Run();