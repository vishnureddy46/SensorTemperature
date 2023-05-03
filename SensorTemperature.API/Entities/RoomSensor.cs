using SensorTemperature.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensorTemperature.API.Entities
{
    public class RoomSensor
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public int NumberofTemperature
        {
            get
            {
                return Temperature.Count;
            }
        }
        public ICollection<Temperature> Temperature { get; set; }
            = new List<Temperature>();

        public RoomSensor(string name) {
         Name = name;
        }
    }
}
