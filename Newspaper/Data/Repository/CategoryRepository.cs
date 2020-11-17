using Microsoft.EntityFrameworkCore;
using Newspaper.Data.Interface;
using Newspaper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.Data.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(NewspaperContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await FindAll().ToListAsync();
        }
    }
}
