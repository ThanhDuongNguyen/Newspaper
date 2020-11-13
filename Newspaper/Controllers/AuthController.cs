using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.DTOs.Input;
using Newspaper.Helpers;
using Newspaper.Services.Interface;

namespace Newspaper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        public AuthController(IAuthService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForCreate userForCreate)
        {
            if (ModelState.IsValid)
            {
                var rs = await _authService.Register(userForCreate);
                if(rs == EnumStatusCode.EmailExist)
                {
                    ModelState.AddModelError("email", "Email đã được đăng ký");
                    return BadRequest(ModelState);
                }
                return Ok();
            }
            return BadRequest(ModelState);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                var user = await _authService.IsLoginValid(loginDTO);
                if (user == null)
                {
                    ModelState.AddModelError("password", "Username hoặc password không đúng");
                    return BadRequest(ModelState);
                }

                var usersClaims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Email)
                };

                var jwtToken = _tokenService.CreateAccessToken(usersClaims);
                user.RefreshToken = _tokenService.CreateRefeshToken();

                await _authService.UpdateUser(user);

                return new ObjectResult(new
                {
                    token = jwtToken,
                    refreshToken = user.RefreshToken
                });
            }
            return BadRequest(ModelState);
        }
    }
}
