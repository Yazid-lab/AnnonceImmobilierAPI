using Firebase.Auth;
using GestionAnnonce.Application.Common.Interfaces;
using GestionAnnonce.Application.Common.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace GestionAnnonce.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IEmailSender _emailSender;

        public AuthController(IAuthService authService, IEmailSender emailSender)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
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
        public async Task<ActionResult> Register(RegistrationRequest request)
        {
            try
            {
                var userDetails = await _authService.Register(request);
                var confirmationLink = Url.Action("ConfirmEmail", "Auth", new
                {
                    userId = userDetails.UserId,
                    token = userDetails.EmailToken
                }, Request.Scheme);
                await _emailSender.SendEmailAsync(request.Email, "Confirm your emial",
                    $"Please confirm your email by clicking here :{confirmationLink}");
                return Ok("User registered. please check your email to confirm it");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
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
            if (id == null)
            {
                return NotFound();
            }
            return Ok(id);

        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return BadRequest("Invalid token.");
            }

            var result = await _authService.ConfirmEmail(userId, token);
            if (result == true) return Ok("Email confirmed successfully.");
            else return BadRequest("Email confirmation failed");
        }
    }
}
