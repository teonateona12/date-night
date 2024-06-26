﻿using AutoMapper;
using date_night_admin.Model;

namespace date_night_admin
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemDto>()
                 .ForMember(dest => dest.CategoryTitle, opt => opt.MapFrom(src => src.Category.Title));

            CreateMap<ItemDto, Item>()
                .ForMember(dest => dest.Category, opt => opt.Ignore());

            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
