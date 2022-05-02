using AutoMapper;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Entities;

namespace TableTracker.Application.MapperProfiles
{
    public class CuisineProfile : Profile
    {
        public CuisineProfile()
        {
            CreateMap<Cuisine, CuisineDTO>()
                .ForMember(dest => dest.Cuisine, opt => opt.MapFrom(src => src.CuisineEnum))
                .ForMember(dest => dest.Restaurants, opt => opt.MapFrom(src => src.Restaurants));

            CreateMap<CuisineDTO, Cuisine>()
                .ForMember(dest => dest.Restaurants, opt => opt.MapFrom(src => src.Restaurants))
                .ForMember(dest => dest.CuisineEnum, opt => opt.MapFrom(src => src.Cuisine));
        }
    }
}
