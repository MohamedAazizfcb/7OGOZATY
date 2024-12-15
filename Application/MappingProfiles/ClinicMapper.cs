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
                .ForMember(dest => dest.ClinicGallery, opt => opt.MapFrom(src => new List<ClinicGallery>()));

            CreateMap<Clinic, ClinicResponse>()
                .ForMember(dest => dest.Address_Ar, opt => opt.MapFrom(src => src.Country.Name_Ar + "؛ " + src.Governorate.Name_Ar + "؛ " + src.District.Name_Ar))
                .ForMember(dest => dest.Address_En, opt => opt.MapFrom(src => src.Country.Name_En + ", " + src.Governorate.Name_En + ", " + src.District.Name_En))
                .ForMember(dest => dest.ClinicGallery, opt => opt.MapFrom(src => src.ClinicGallery.Select(g => g.imgUrl)));


        }
    }
}