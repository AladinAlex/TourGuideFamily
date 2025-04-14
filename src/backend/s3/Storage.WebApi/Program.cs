using Storage.WebApi.GrpcServices;
using Storage.Bll;
using Microsoft.Extensions.FileProviders;
using Storage.Bll.Consts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc(options =>
{
    options.MaxReceiveMessageSize = 1024 * 1024 * 35; // 25 MB
    //interceptors
}).AddJsonTranscoding();


builder.Services.AddGrpcReflection();
builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen();

builder.Services.AddServices();

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

app.MapGet("/health", () => Results.Ok("Healthy"));

app.Run();