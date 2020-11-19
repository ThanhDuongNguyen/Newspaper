using AutoMapper;
using Newspaper.DTOs.Input;
using Newspaper.Helpers;
using Newspaper.Models;
using Newspaper.Services.Interface;
using NewspaperProject.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.Services
{
    public class NewspaperService : INewspaperService
    {
        private readonly INewspaperRepository _newspaperRepository;
        private readonly IMapper _mapper;
        public NewspaperService(INewspaperRepository newspaperRepository, IMapper mapper)
        {
            _newspaperRepository = newspaperRepository;
            _mapper = mapper;
        }

        public async Task<int> AddNewspaper(NewspaperForCreate newspaperForCreate)
        {
            var newspaper = _mapper.Map<NewspaperModel>(newspaperForCreate);
            newspaper.Date = DateTime.Now;
            newspaper.Status = true;
            newspaper.View = 0;
            return await _newspaperRepository.AddNewspaper(newspaper);
        }

        public async Task<IEnumerable<NewspaperModel>> GetAllNewspaper(NewspaperParameters newspaperParameters)
        {
            return await _newspaperRepository.GetAllNewpapersAsync(newspaperParameters);
        }

        public async Task<NewspaperModel> GetNewspaper(int id)
        {
            return await _newspaperRepository.GetNewpapersAsync(id);
        }
    }
}
