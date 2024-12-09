using Application.Dtos.Clinic;
using AutoMapper;
using Domain.Entities.ClinicEntity;

namespace Application.MappingProfiles
{
    public class ClinicMpper : Profile
    {
        public ClinicMpper()
        {
            CreateMap<ClinicRequest, Clinic>()
                .ForMember(dest => dest.Gallery, opt => opt.MapFrom(src => new List<ClinicGallery>()));
        }
    }
}