using SensorTemperature.API.Models;

namespace SensorTemperature.API
{
    public class RoomSensorDataStore
    {
        public List<RoomSensorDto> RoomSensor { get; set; }
        public static RoomSensorDataStore Current { get; } = new RoomSensorDataStore();

        public RoomSensorDataStore()
        {
            //dummy data
            RoomSensor = new List<RoomSensorDto>()
            {
                new RoomSensorDto()
                {
                    Id = 1,
                    Name = "Room 1",
                    Temperature = new List<TemperatureDto>()
                    {
                        new TemperatureDto()
                        {
                            Celsius = 60
                        },
                        new TemperatureDto()
                        {
                            Celsius = 80
                        },
                    }
                },
                 new RoomSensorDto()
                 {
                     Id = 2,
                     Name = "Room2",
                     Temperature = new List<TemperatureDto>()
                    {
                     new TemperatureDto()
                        {
                            Celsius = 70
                        },
                        new TemperatureDto()
                        {
                            Celsius = 90
                        },
                     }
                 } 
            };

        }
    }
}
