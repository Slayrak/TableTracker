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
            CreateMap<Domain.Entities.Cuisine, CuisineDTO>()
                .ForMember(dest => dest.Cuisine, opt => opt.MapFrom(src => src.CuisineEnum))
                .ForMember(dest => dest.Restaurants, opt => opt.MapFrom(src => src.Restaurants));

            CreateMap<CuisineDTO, Domain.Entities.Cuisine>()
                .ForMember(dest => dest.Restaurants, opt => opt.MapFrom(src => src.Restaurants))
                .ForMember(dest => dest.CuisineEnum, opt => opt.MapFrom(src => src.Cuisine));
        }
    }
}
