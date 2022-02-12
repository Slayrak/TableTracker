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
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationDTO>()
                .ForMember(dest => dest.Visitors, opt => opt.MapFrom(src => src.Visitors))
                .ForMember(dest => dest.Table, opt => opt.MapFrom(src => src.Table));

            CreateMap<ReservationDTO, Reservation>()
                .ForMember(dest => dest.Visitors, opt => opt.MapFrom(src => src.Visitors))
                .ForMember(dest => dest.Table, opt => opt.MapFrom(src => src.Table));
        }
    }
}
