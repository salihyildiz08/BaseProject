using AutoMapper;
using DtoLayer.CategoryDto;
using DtoLayer.UserDto;
using EntityLayer.Concrete;

namespace WebApi.Mapping
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
        }
    }
}
