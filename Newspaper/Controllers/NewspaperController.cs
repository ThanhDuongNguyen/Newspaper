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
        public async Task<IActionResult> GetAllNewspapers([FromQuery] NewspaperParameters employeeParameters)
        {
            var newspapers = await _newspaperService.GetAllNewspaper(employeeParameters);
            int num = await _newspaperService.GetNewsCateNumber(employeeParameters.CategoryID);
            return Ok(new { listNews = newspapers, length = num });
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNewspaper(int id)
        {
            return Ok(await _newspaperService.GetNewspaper(id));
        }


        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddNewspaper(NewspaperForCreate newspaper)
        {
            return Ok(await _newspaperService.AddNewspaper(newspaper));
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewspaper(int id)
        {
            return Ok(await _newspaperService.DeleteNewspaper(id));
        }

        [Authorize(Policy = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateNewspaper(NewspaperModel newspaper)
        {
            return Ok(await _newspaperService.UpdateNewspaper(newspaper));
        }
    }
}
