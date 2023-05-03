namespace SensorTemperature.API.Models
{
    public class RoomSensorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int NumberofTemperature
        {
            get
            {
                return Temperature.Count;
            }
        }
        public  ICollection<TemperatureDto> Temperature { get; set; }
            = new List<TemperatureDto>();
    }
}
