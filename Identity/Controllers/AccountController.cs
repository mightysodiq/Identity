using Identity.Logic;
using Identity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto request)
        {
             return Ok (await _authenticationService.CreateUser(request));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string email, string password )
        {
            return Ok(await _authenticationService.Login(email,password));
        }
    }
}
