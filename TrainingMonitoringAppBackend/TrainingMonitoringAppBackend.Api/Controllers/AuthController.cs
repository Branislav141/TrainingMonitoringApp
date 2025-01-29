using Microsoft.AspNetCore.Mvc;
using TrainingMonitoringAppBackend.Application.Dtos;
using TrainingMonitoringAppBackend.Application.Interfaces;
using System.Threading.Tasks;

namespace TrainingMonitoringAppBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            try
            {
                await _userService.RegisterUserAsync(registerModel);
                return Ok(new { Message = "Registration succeeded" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            try
            {
                var token = await _userService.LoginUserAsync(loginModel);

                if (string.IsNullOrEmpty(token))
                {
                    return BadRequest("Invalid login credentials");
                }

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
