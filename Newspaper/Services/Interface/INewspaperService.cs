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
    }
}
