using AutoMapper;
using Newspaper.DTOs.Input;
using Newspaper.Models;

namespace Newspaper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForCreate, User>();
        }
    }
}
