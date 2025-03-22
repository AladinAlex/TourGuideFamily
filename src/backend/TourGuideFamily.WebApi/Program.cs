using TourGuideFamily.Dal.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;

//services.AddControllers();
services
    //.AddOpenApi()
    .AddLogging()
    .AddDalRepositories()
    .AddDalInfrastructure(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
    app.MapOpenApi();
//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();
//app.MigrateDown();
app.MigrateUp();

app.Run();
