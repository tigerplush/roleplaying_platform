using Corgi.Backend.Dtos.v1;
using Corgi.Backend.Models;
using Corgi.Backend.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corgi.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<GetUserDtoV1>> CreateNewUserAsync(AddUserDtoV1 userDto)
        {
            User existingUser = await _userService.GetUserByIdAsync(userDto.Id);
            if(existingUser != null)
            {
                return Conflict();
            }
            User user = await _userService.CreateNewUserAsync(userDto.Id, userDto.Name);
            return Ok(user);
        }
    }
}
