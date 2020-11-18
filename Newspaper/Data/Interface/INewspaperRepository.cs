using Newspaper.Helpers;
using Newspaper.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewspaperProject.Data.Interface
{
    public interface INewspaperRepository
    {
        Task<IEnumerable<NewspaperModel>> GetNewpapersAsync(NewspaperParameters newspaperParameters);

        Task<int> AddNewspaper(NewspaperModel newspaper);
    }
}
