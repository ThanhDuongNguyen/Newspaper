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
                newspapers = await FindByCondition(x => x.CategoryID.Equals(newspaperParameters.CategoryID) && x.Status == true)
                    .OrderBy(e => e.Date)
                .Skip((newspaperParameters.PageNumber - 1) * newspaperParameters.PageSize)
                .Take(newspaperParameters.PageSize)
                .ToListAsync();
            }
            else
            {
                newspapers = await FindAll().Where(x=> x.Status == true).OrderBy(e => e.Date)
                .Skip((newspaperParameters.PageNumber - 1) * newspaperParameters.PageSize)
                .Take(newspaperParameters.PageSize)
                .ToListAsync();
            }


            foreach(var news in newspapers)
            {
                await _context.Entry(news).Reference(x => x.Category).LoadAsync();
                await _context.Entry(news).Reference(x => x.Author).LoadAsync();
            }
            return newspapers;
        }

        public async Task<NewspaperModel> GetNewpapersAsync(int id)
        {
            var news = await FindByCondition(x => x.PageID.Equals(id)).SingleOrDefaultAsync();
            await _context.Entry(news).Reference(x => x.Category).LoadAsync();
            return news;
        }

        public async Task<int> NewspaperCateNumber(int? CatID)
        {
            return await FindByCondition(x => x.CategoryID.Equals(CatID) && x.Status == true).CountAsync();
        }

        public async Task<int> DeleteNewspaper(int id)
        {
            var newspaper = await FindByCondition(x => x.PageID.Equals(id)).SingleOrDefaultAsync();
            if (newspaper == null) return -1;
            newspaper.Status = false;
            return await SaveChangeAsync();
        }

        public async Task<int> UpdateNewspaper(NewspaperModel newspaper)
        {
            Update(newspaper);
            return await SaveChangeAsync();
        }


    }
}
