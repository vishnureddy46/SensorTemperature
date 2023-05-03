using Microsoft.AspNetCore.Mvc;
using SensorTemperature.API.Models;

namespace SensorTemperature.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomSensorController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetRoomSensor()
        {
            return new JsonResult(RoomSensorDataStore.Current.RoomSensor);
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<RoomSensorDto>> GetRoomTemperature(int id)
        {
            var room = RoomSensorDataStore.Current.RoomSensor.FirstOrDefault(x => x.Id == id);
            if (room == null)

            {
                return NotFound();
            }
            return Ok(room);
        }
    }
}
