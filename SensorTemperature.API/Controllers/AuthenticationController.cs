using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace SensorTemperature.API.Controllers
{
  [Route("api/authentication")]
  [ApiController]
  public class AuthenticationController : ControllerBase
  {
    public class AuthenticationRequestBody
    {
      public string? Username { get; set; }
      public string? Password { get; set; }
    }
    private class SensorTemperature
    {
      private readonly IConfiguration _configuration;

      public int UserId { get; set; }
      public string UserName { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Room { get; set; }

      public SensorTemperature(int userId, string userName, string firstName, string lastName, string room)
      {
        UserId = userId;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        Room = room;
      }
      public AuthenticationController(IConfiguration configuration)
      {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
      }
      [HttpPost("authenticate")]
      public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
      {
        var user = ValidateUserCredentials(
          authenticationRequestBody.Username,
          authenticationRequestBody.Password);
        if (user == null)
        {
          return Unauthorized();
        }
        //create token
        var securitykey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication.SecretForKey"]));
      }

      private SensorTemperature ValidateUserCredentials(string? userName, string? password)
      {
        return new SensorTemperature(1, userName ?? "", "vishnu", "reddy", "room1");
      }
    }
  }
}
