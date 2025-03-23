using TourGuideFamily.Dal.Extensions;
using TourGuideFamily.Bll;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services
    .AddOpenApi()
    .AddLogging()
    .AddDalInfrastructure(builder.Configuration)
    .AddDalRepositories()
    .AddServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.UseSwaggerUi();
}



//app.UseHttpsRedirection();
//app.UseAuthorization();
app.MapControllers();
//app.MigrateDown();

app.MigrateUp();

app.Run();
