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
    public class VisitorFavouritesProfile : Profile
    {
        public VisitorFavouritesProfile()
        {
            CreateMap<VisitorFavourites, VisitorFavouritesDTO>()
                .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant))
                .ForMember(dest => dest.Visitor, opt => opt.MapFrom(src => src.Visitor));

            CreateMap<VisitorFavouritesDTO, VisitorFavourites>()
                .ForMember(dest => dest.Visitor, opt => opt.MapFrom(src => src.Visitor))
                .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant));
        }
    }
}
