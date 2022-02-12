using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Entities;

namespace TableTracker.Application.MapperProfiles
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantDTO>()
               .ForMember(dest => dest.Franchise, opt => opt.MapFrom(src => src.Franchise))
               .ForMember(dest => dest.Layout, opt => opt.MapFrom(src => src.Layout))
               .ForMember(dest => dest.Waiters, opt => opt.MapFrom(src => src.Waiters))
               .ForMember(dest => dest.Cuisines, opt => opt.MapFrom(src => src.Cuisines))
               .ForMember(dest => dest.Tables, opt => opt.MapFrom(src => src.Tables));

            CreateMap<RestaurantDTO, Restaurant>()
                .ForMember(dest => dest.Franchise, opt => opt.MapFrom(src => src.Franchise))
                .ForMember(dest => dest.Layout, opt => opt.MapFrom(src => src.Layout))
                .ForMember(dest => dest.Waiters, opt => opt.MapFrom(src => src.Waiters))
                .ForMember(dest => dest.Cuisines, opt => opt.MapFrom(src => src.Cuisines))
                .ForMember(dest => dest.Tables, opt => opt.MapFrom(src => src.Tables));
        }
    }
}
