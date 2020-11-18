using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.DTOs.Input;
using Newspaper.Helpers;
using Newspaper.Models;
using Newspaper.Services.Interface;
using NewspaperProject.Data.Interface;

namespace Newspaper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewspaperController : ControllerBase
    {
        private readonly INewspaperService _newspaperService;
       
        public NewspaperController(INewspaperService newspaperService)
        {
            _newspaperService = newspaperService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetNewspaper([FromQuery]NewspaperParameters employeeParameters)
        {
            return Ok(await _newspaperService.GetAllNewspaper(employeeParameters));
        }


        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddNewspaper(NewspaperForCreate newspaper)
        {
            return Ok(await _newspaperService.AddNewspaper(newspaper));
        }
    }
}
