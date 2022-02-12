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
                .ForMember(dest => dest.Tables, opt => opt.MapFrom(src => src.Tables))
                .ForMember(dest => dest.Reservations, opt => opt.MapFrom(src => src.Reservations));
        }
    }
}
