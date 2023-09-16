using GestionAnnonce.Application.Common.Interfaces;
using GestionAnnonce.Application.Common.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace GestionAnnonce.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            try
            {

                return Ok(await _authService.Login(request));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Unauthorized();
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            try
            {

                return Ok(await _authService.Register(request));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout();
            return Ok();
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<ApplicationUserDto>>> GetUsers()
        {
            var users = await _authService.GetUsers();
            return Ok(users);
        }

        [HttpGet("user-info/{id}")]

        public async Task<ActionResult<ApplicationUserDto>> GetUserInfoById(string id)
        {
            var userInfo = await _authService.GetUserInfoById(id);
            return Ok(userInfo);
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteUser(string userId)
        {
            var id = await _authService.DeleteUser(userId);
            if (id  ==null)
            {
                return NotFound(); 
            }
            return Ok(id);

        }
    }
}
