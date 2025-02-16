using AutoMapper;
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
        private readonly IMapper _mapper;

        public UsersController(
            IUserService userService,
            IMapper mapper
            )
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPut]
        public async Task<ActionResult<GetUserDtoV1>> CreateOrUpdateUserAsync(AddUserDtoV1 userDto)
        {
            User existingUser = await _userService.GetUserByIdAsync(userDto.Id);
            if(existingUser != null)
            {
                existingUser = await _userService.UpdateUserAsync(existingUser);
                return Ok(_mapper.Map<GetUserDtoV1>(existingUser));
            }
            User user = await _userService.CreateNewUserAsync(userDto.Id, userDto.Name);
            return Ok(_mapper.Map<GetUserDtoV1>(user));
        }
    }
}
