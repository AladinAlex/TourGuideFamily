using Storage.WebApi.GrpcServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc(options =>
{
    //interceptors
}).AddJsonTranscoding();


builder.Services.AddGrpcReflection();
builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGrpcReflectionService();
}

app.MapGrpcService<UploadFileServiceGrpc>();
app.Run();














//builder.Services.AddControllers();
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
