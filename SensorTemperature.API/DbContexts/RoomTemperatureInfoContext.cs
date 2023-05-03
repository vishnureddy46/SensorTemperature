using Microsoft.EntityFrameworkCore;
using SensorTemperature.API.Entities;

namespace SensorTemperature.API.DbContexts
{
    public class RoomTemperatureInfoContext : DbContext
    {
        public DbSet<RoomSensor> RoomSensors { get; set; } = null!;
        public DbSet<Temperature> Temperatures { get; set; } = null!;
        public RoomTemperatureInfoContext(DbContextOptions<RoomTemperatureInfoContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomSensor>().HasData(
                new RoomSensor("Room 1")
                {
                    Id =1
                },
                new RoomSensor("Room 2")
                {
                    Id=2
                });
            modelBuilder.Entity<Temperature>().HasData(
                new Temperature
                {
                    Id = 1,
                    RoomSensorId = 1,
                    Celsius = 60
                },
                new Temperature
                {
                    Id = 2,
                    RoomSensorId = 1,
                    Celsius = 90
                },
                new Temperature
                {
                    Id = 3,
                    RoomSensorId = 2,
                    Celsius = 70
                },
                new Temperature
                {
                    Id = 4,
                    RoomSensorId = 2,
                    Celsius = 80
                });
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
