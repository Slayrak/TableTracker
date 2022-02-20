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
    public class CuisinesProfile : Profile
    {
        public CuisinesProfile()
        {
            CreateMap<Domain.Entities.Cuisines, CuisinesDTO>()
                .ForMember(dest => dest.Cuisine, opt => opt.MapFrom(src => src.Cuisine))
                .ForMember(dest => dest.Restaurants, opt => opt.MapFrom(src => src.Restaurants));

            CreateMap<CuisinesDTO, Domain.Entities.Cuisines>()
                .ForMember(dest => dest.Restaurants, opt => opt.MapFrom(src => src.Restaurants))
                .ForMember(dest => dest.Cuisine, opt => opt.MapFrom(src => src.Cuisine));
        }
    }
}
