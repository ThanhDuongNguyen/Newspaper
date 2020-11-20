using Newspaper.DTOs.Input;
using Newspaper.Helpers;
using Newspaper.Models;
using NewspaperProject.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.Services.Interface
{
    public interface INewspaperService
    {

        public Task<int> AddNewspaper(NewspaperForCreate newspaperForCreate);

        public Task<IEnumerable<NewspaperModel>> GetAllNewspaper(NewspaperParameters newspaperParameters);

        public Task<NewspaperModel> GetNewspaper(int id);

        public Task<int> GetNewsCateNumber(int? CatID);

        public Task<int> DeleteNewspaper(int id);

        public Task<int> UpdateNewspaper(NewspaperModel newspaper);
    }
}
