using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
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
    }
}
