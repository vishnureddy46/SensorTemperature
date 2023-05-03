using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SensorTemperature.API.Entities
{
    public class Temperature
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public int Celsius { get; set; }
        [ForeignKey("RoomSensorId")]
        public RoomSensor? RoomSensor { get; set; }
        public int RoomSensorId { get; set; }

    }
}
