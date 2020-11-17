using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.DTOs.Input;
using Newspaper.Services.Interface;

namespace Newspaper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public readonly IAuthService _authServer;
        public TokenController(ITokenService tokenService, IAuthService authServer)
        {
            _tokenService = tokenService;
            _authServer = authServer;
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> Refresh(TokenDTO tokenDTO)
        {
            if (ModelState.IsValid)
            {
                string accessToken = tokenDTO.AccessToken;
                string refreshToken = tokenDTO.RefreshToken;
                var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
                var email = principal.FindFirst(ClaimTypes.Email).Value;

                var user = await _authServer.GetUser(email);

                if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                {
                    return BadRequest("Yêu cầu không hợp lệ");
                }
                var newAccessToken = _tokenService.CreateAccessToken(user);
                var newRefreshToken = _tokenService.CreateRefreshToken();

                user.RefreshToken = newRefreshToken;
                await _authServer.UpdateUser(user);
                return new ObjectResult(new
                {
                    accessToken = newAccessToken,
                    refreshToken = newRefreshToken
                });
            }
            return BadRequest(ModelState);
        }
    }
}
