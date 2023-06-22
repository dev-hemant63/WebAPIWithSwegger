using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.AppCode.Interface;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _account;
        public AccountController(IAccountService account)
        {
            _account = account;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(ApplicationUser request)
        {
            var res = await _account.SignUp(request);
            return Ok(res);
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(string Mobile,string Password)
        {
            ApplicationUser request = new ApplicationUser
            {
                Mobile = Mobile,
                Password = Password
            };
            var data = await _account.SignIn(request);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,data.Name),
                new Claim(ClaimTypes.Email,data.EmailID),
                new Claim(ClaimTypes.MobilePhone,data.Mobile),
                new Claim(ClaimTypes.UserData,data.Password),
            };
            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var AuthProps = new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(2)
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimIdentity), AuthProps);
            return Ok(new
            {
                Statuscode = 1,
                Msg = "SignIn Success!",
                Name = User.Identity.Name
            });
        }
    }
}
