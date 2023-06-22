using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.AppCode.Attributes;
using WebAPI.AppCode.Interface;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _token;
        public AuthenticationController(ITokenService token)
        {
            _token = token;
        }
        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login()
        {
            var user = new UserDetails
            {
                Id = 1,
                Name = "Hemant",
                Role = "Admin"
            };
            var token = await _token.GenerateTokenAsync(user);
            return Ok(new
            {
                Token  = token
            });
        }
        [HttpPost(nameof(UserInfo))]
        [AuthorizedUser]
        public async Task<IActionResult> UserInfo()
        {
            var user = new UserDetails
            {
                Id = 1,
                Name = "Hemant",
                Role = "Admin"
            };
            return Ok(user);
        }
    }
}
