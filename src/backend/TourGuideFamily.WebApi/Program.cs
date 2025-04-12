using TourGuideFamily.Bll;
using TourGuideFamily.Dal.Extensions;
using TourGuideFamily.WebApi.Models;

var builder = WebApplication.CreateBuilder(args);
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
    .AddServices()
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.UseSwaggerUi();
}


app.UseCors("VuePolicy");
//app.UseHttpsRedirection();
//app.UseAuthorization();
app.MapControllers();
//app.MigrateDown();

app.MigrateUp();

app.Run();
