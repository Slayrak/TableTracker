using AutoMapper;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Entities;

namespace TableTracker.Application.MapperProfiles
{
    public class VisitorProfile : Profile
    {
        public VisitorProfile()
        {
            CreateMap<Visitor, VisitorDTO>()
                .ForMember(dest => dest.Reservations, opt => opt.MapFrom(src => src.Reservations));

            CreateMap<VisitorDTO, Visitor>()
                .ForMember(dest => dest.Reservations, opt => opt.MapFrom(src => src.Reservations));
        }
    }
}
