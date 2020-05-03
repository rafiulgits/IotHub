using IotHub.DataTransferObjects.User;
using IotHub.Services.User;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IotHub.API.Controllers
{
    [Route("/api/users")]
    public class UserController : IotHubBaseController
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetAsync([FromRoute] string id)
        {
            return await userService.GetUserAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateAsync([FromBody] UserUpsertDto user)
        {
            var createdUser = await userService.CreateUserAsync(user);
            return Created("", createdUser);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllAsync()
        {
            var users = await userService.GetAllAsync();
            return Ok(users);
        }
    }
}
