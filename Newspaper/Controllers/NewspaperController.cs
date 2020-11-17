using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Helpers;
using NewspaperProject.Data.Interface;

namespace Newspaper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewspaperController : ControllerBase
    {
        private readonly INewspaperRepository _newspaperRepository;
        public NewspaperController(INewspaperRepository newspaperRepository)
        {
            _newspaperRepository = newspaperRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetNewspaper(EmployeeParameters employeeParameters)
        {
            return Ok(await _newspaperRepository.GetNewpapersAsync(employeeParameters));
        }
    }
}
