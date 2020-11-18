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

        public async Task<int> AddNewspaper(NewspaperModel newspaper)
        {
            Create(newspaper);
            return await SaveChangeAsync();
        }

        public async Task<IEnumerable<NewspaperModel>> GetNewpapersAsync(NewspaperParameters newspaperParameters)
        {
            return await FindAll()
            .OrderBy(e => e.Date)
            .Skip((newspaperParameters.PageNumber - 1) * newspaperParameters.PageSize)
            .Take(newspaperParameters.PageSize)
            .ToListAsync();
        }
    }
}
