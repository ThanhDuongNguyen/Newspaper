using AutoMapper;
using Newspaper.DTOs.Input;
using Newspaper.DTOs.Output;
using Newspaper.Models;

namespace Newspaper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForCreate, User>();
            CreateMap<User, UserForView>().
                ForMember(x => x.Role, opt => opt.MapFrom(x => x.Role.RoleName));
        }
    }
}
