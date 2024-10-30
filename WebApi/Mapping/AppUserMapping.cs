using AutoMapper;
using DtoLayer.UserDto;
using EntityLayer.Concrete;

namespace WebApi.Mapping
{
    public class AppUserMapping : Profile
    {
        public AppUserMapping()
        {
            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppUser, ResultUserDto>().ReverseMap();
        }
    }
}
