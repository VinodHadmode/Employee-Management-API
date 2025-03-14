using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/auth/login
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var token = _authService.Authenticate(user);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { Token = token });
        }
    }
}
