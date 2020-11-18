using Microsoft.EntityFrameworkCore;
using Newspaper.Data.Interface;
using Newspaper.Helpers;
using Newspaper.Models;
using NewspaperProject.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.Data.Repository
{
    public class NewspaperRepository : RepositoryBase<NewspaperModel>, INewspaperRepository
    {
        public NewspaperRepository(NewspaperContext context) : base(context)
        {
        }

        public async Task<IEnumerable<NewspaperModel>> GetNewpapersAsync(EmployeeParameters employeeParameters)
        {
            return await FindAll()
            .OrderBy(e => e.Date)
            .Skip((employeeParameters.PageNumber - 1) * employeeParameters.PageSize)
            .Take(employeeParameters.PageSize)
            .ToListAsync();
        }
    }
}
