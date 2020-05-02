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

        public async Task<ActionResult<UserDto>> Login([FromBody] string username, [FromBody] string password)
        {
            return await authenticationService.Authenticate(username, password);
        }
    }
}
