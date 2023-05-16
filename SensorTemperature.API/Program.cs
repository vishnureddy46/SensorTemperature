using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using SensorTemperature.API;
using SensorTemperature.API.DbContexts;
using SensorTemperature.API.Services;
using Serilog;

Log.Logger = new LoggerConfiguration()
  .MinimumLevel.Debug()
  .WriteTo.Console()
  .WriteTo.File("logs/roomtemperature.txt", rollingInterval: RollingInterval.Day)
  .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
builder.Services.AddSingleton<RoomSensorDataStore>();
builder.Services.AddDbContext<RoomTemperatureInfoContext>(
    DbContextOptions=> DbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:RoomTemperatureDbConnectionString"]));
builder.Services.AddTransient<LocalMailService> ();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
