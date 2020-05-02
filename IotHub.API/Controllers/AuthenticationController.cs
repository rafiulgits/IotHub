using IotHub.DataTransferObjects.User;
using IotHub.Services.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IotHub.API.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : IotHubBaseController
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] UserLoginDto loginData)
        {
            return await authenticationService.Authenticate(loginData.Name, loginData.Password);
        }
    }
}
