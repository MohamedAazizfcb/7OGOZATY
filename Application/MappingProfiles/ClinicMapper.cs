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
                .ForMember(dest => dest.Country_En, opt => opt.MapFrom(src => src.Country.Name_En))
                .ForMember(dest => dest.Country_Ar, opt => opt.MapFrom(src => src.Country.Name_Ar))
                .ForMember(dest => dest.Governorate_En, opt => opt.MapFrom(src => src.Governorate.Name_En))
                .ForMember(dest => dest.Governorate_Ar, opt => opt.MapFrom(src => src.Governorate.Name_Ar))
                .ForMember(dest => dest.District_En, opt => opt.MapFrom(src => src.District.Name_En))
                .ForMember(dest => dest.District_Ar, opt => opt.MapFrom(src => src.District.Name_Ar))
                .ForMember(dest => dest.ClinicGallery, opt => opt.MapFrom(src => src.ClinicGallery.Select(g => g.imgUrl)));
        }
    }
}