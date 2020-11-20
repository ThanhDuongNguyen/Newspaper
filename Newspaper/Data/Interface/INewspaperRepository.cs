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

        Task<int> NewspaperCateNumber(int? CatID);
        Task<int> AddNewspaper(NewspaperModel newspaper);

        Task<int> UpdateNewspaper(NewspaperModel newspaper);

        Task<int> DeleteNewspaper(int id);
    }
}
