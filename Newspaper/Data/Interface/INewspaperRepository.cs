using Newspaper.Helpers;
using Newspaper.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewspaperProject.Data.Interface
{
    public interface INewspaperRepository
    {
        Task<IEnumerable<NewspaperModel>> GetAllNewpapersAsync(NewspaperParameters newspaperParameters);
        Task<NewspaperModel> GetNewpapersAsync(int id);

        Task<int> AddNewspaper(NewspaperModel newspaper);


    }
}
