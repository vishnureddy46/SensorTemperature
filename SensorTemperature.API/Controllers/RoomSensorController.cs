using Microsoft.AspNetCore.Mvc;
using SensorTemperature.API.Entities;
using SensorTemperature.API.Models;
using SensorTemperature.API.Services;

namespace SensorTemperature.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RoomSensorController : ControllerBase
  {
    private readonly ILogger<RoomSensorController> _logger;
    private readonly LocalMailService _mailService;

    public RoomSensorController(ILogger<RoomSensorController> logger, LocalMailService mailService) {
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
      _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
    }
    [HttpGet]
    //public JsonResult GetRoomSensor()
    //{
    //  _mailService.Send("Room Sensor Id was not found");

    //  return new JsonResult(RoomSensorDataStore.Current.RoomSensor);
    //}
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<RoomSensorDto>> GetRoomTemperature(int id)
    {
      try
      {
        //throw new Exception("Exception Sample.");

        var room = RoomSensorDataStore.Current.RoomSensor.FirstOrDefault(x => x.Id == id);
        if (room == null)

        {
          _logger.LogInformation($"Room with Id {id} wasn't found");
          return NotFound();
        }
        
        return Ok(room);
      }
      catch (Exception ex) {
        _logger.LogCritical($"Exception while getting room sensor with Id {id}", ex);
        return StatusCode(500, "A problem happened while handling your error");
      }

    }
    }
}
