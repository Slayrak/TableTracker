using AutoMapper;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Entities;

namespace TableTracker.Application.MapperProfiles
{
    public class WaiterProfile : Profile
    {
        public WaiterProfile()
        {
            CreateMap<Waiter, WaiterDTO>()
                .ForMember(dest => dest.Tables, opt => opt.MapFrom(src => src.Tables))
                .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant))
                .ForMember(dest => dest.Reservations, opt => opt.MapFrom(src => src.Reservations));

            CreateMap<WaiterDTO, Waiter>()
                .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant))
                .ForMember(dest => dest.RestaurantId, opt => opt.MapFrom(src => src.Restaurant.Id))
                .ForMember(dest => dest.Tables, opt => opt.MapFrom(src => src.Tables))
                .ForMember(dest => dest.Reservations, opt => opt.MapFrom(src => src.Reservations));
        }
    }
}
