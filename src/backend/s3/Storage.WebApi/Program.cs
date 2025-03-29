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
string filesPath = Path.Combine(AppContext.BaseDirectory, StorageResourse.ResourseFolderName);
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(filesPath),
    RequestPath = $"/{StorageResourse.ResourseFolderName}",
    ServeUnknownFileTypes = true,
    DefaultContentType = "application/octet-stream"
});
app.MapGrpcService<UploadFileServiceGrpc>();
app.Run();