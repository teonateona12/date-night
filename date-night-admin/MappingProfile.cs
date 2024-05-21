using AutoMapper;
using date_night_admin.Model;

namespace date_night_admin
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
