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

        public async Task<IEnumerable<NewspaperModel>> GetAllNewpapersAsync(NewspaperParameters newspaperParameters)
        {
            List<NewspaperModel> newspapers;

            if(newspaperParameters.CategoryID != null) {
                newspapers = await FindByCondition(x => x.CategoryID.Equals(newspaperParameters.CategoryID))
                    .OrderBy(e => e.Date)
                .Skip((newspaperParameters.PageNumber - 1) * newspaperParameters.PageSize)
                .Take(newspaperParameters.PageSize)
                .ToListAsync(); ;
            }
            else
            {
                newspapers = await FindAll().OrderBy(e => e.Date)
                .Skip((newspaperParameters.PageNumber - 1) * newspaperParameters.PageSize)
                .Take(newspaperParameters.PageSize)
                .ToListAsync();
            }

            foreach(var news in newspapers)
            {
                await _context.Entry(news).Reference(x => x.Category).LoadAsync();
            }
            return newspapers;
        }

        public async Task<NewspaperModel> GetNewpapersAsync(int id)
        {
            var news = await FindByCondition(x => x.PageID.Equals(id)).SingleOrDefaultAsync();
            await _context.Entry(news).Reference(x => x.Category).LoadAsync();
            return news;
        }
    }
}
