using Newspaper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.Data.Interface
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllCategoryAsync();
    }
}
