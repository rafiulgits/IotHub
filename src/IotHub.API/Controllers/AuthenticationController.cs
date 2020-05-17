using IotHub.API.Extentions;
using IotHub.API.Services;
using IotHub.DataTransferObjects.User;
using IotHub.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IotHub.API.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : IotHubBaseController
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IInternalService internalService;

        public AuthenticationController(IAuthenticationService authenticationService, IInternalService internalService)
        {
            this.authenticationService = authenticationService;
            this.internalService = internalService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserTokenDto>> Login([FromBody] UserLoginDto loginData)
        {
            var user = await authenticationService.Authenticate(loginData.Name, loginData.Password);
            if(user == null)
            {
                return Unauthorized("Invalid credential");
            }
            var userToken = new UserTokenDto() { Bearer = user.GetJwtToken() };
            return Ok(userToken);
        }

        [HttpPost("internal-login")]
        public ActionResult<UserTokenDto> InternalLogin([FromBody] UserLoginDto loginData)
        {
            var userToken = internalService.InternalAuthentication(loginData);
            if(userToken == null)
            {
                return Unauthorized();
            }
            return Ok(userToken);
        }

        [Authorize]
        [HttpGet("validate")]
        public ActionResult Validate()
        {
            System.Console.WriteLine("validate invoked");
            return NoContent();
        }
    }
}
