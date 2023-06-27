using Domain.Entities;
using GestionAnnonce.Application.Common.Services;
using GestionAnnonce.Application.Users.Commands.UpdateUser;
using Microsoft.AspNetCore.Mvc;

namespace GestionAnnonce.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpPut("{userId:int}")]
        public async Task<ActionResult<User>> UpdateUser(int userId, UpdateUserDto updatedUser)
        {
            var id = await _userService.UpdateUser(userId, updatedUser);
            if (id < 0) return NotFound();
            return Ok(updatedUser);

        }

        [HttpDelete("{userId:int}")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            var id = await _userService.DeleteUser(userId);
            if (id < 0)
            {
                return NotFound();

            }
            return Ok(id);
        }
    }
}
