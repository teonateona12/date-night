using AutoMapper;
using date_night_user.Model;

namespace date_night_user
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemDto>()
                 .ForMember(dest => dest.CategoryTitle, opt => opt.MapFrom(src => src.Category.Title));

            CreateMap<ItemDto, Item>()
                .ForMember(dest => dest.Category, opt => opt.Ignore());
        }
    }
}
