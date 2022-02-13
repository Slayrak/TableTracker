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
    public class TableProfile : Profile
    {
        public TableProfile()
        {
            CreateMap<Table, TableDTO>()
                .ForMember(dest => dest.Reservations, opt => opt.MapFrom(src => src.Reservations))
                .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant))
                .ForMember(dest => dest.Waiter, opt => opt.MapFrom(src => src.Waiter));

            CreateMap<TableDTO, Table>()
                .ForMember(dest => dest.Waiter, opt => opt.MapFrom(src => src.Waiter))
                .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant))
                .ForMember(dest => dest.Reservations, opt => opt.MapFrom(src => src.Reservations));
        }
    }
}
