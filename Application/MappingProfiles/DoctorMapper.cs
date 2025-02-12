using Application.Dtos.AppointmentDTO.Request;
using Application.Dtos.AppointmentDTO.Response;
using Application.Dtos.DoctorDTO.Request;
using Application.Dtos.DoctorDTO.Response;
using AutoMapper;
using Domain.Entities.AppointmentEntities;
using Domain.Entities.SpecializationServicesEntity;
using Domain.Entities.User;

namespace Application.MappingProfiles
{
    public class DoctorMapper : Profile
    {
        public DoctorMapper()
        {
            CreateMap<AddServiceToDoctorRequest, DoctorServicePivot>();

            CreateMap<Doctor, DoctorResponse>()
                .ForMember(dest => dest.Gender_En, opt => opt.MapFrom(src => src.Gender.Name_En))
                .ForMember(dest => dest.Gender_Ar, opt => opt.MapFrom(src => src.Gender.Name_Ar))
                .ForMember(dest => dest.Country_En, opt => opt.MapFrom(src => src.Country.Name_En))
                .ForMember(dest => dest.Country_Ar, opt => opt.MapFrom(src => src.Country.Name_Ar))
                .ForMember(dest => dest.Governorate_En, opt => opt.MapFrom(src => src.Governorate.Name_En))
                .ForMember(dest => dest.Governorate_Ar, opt => opt.MapFrom(src => src.Governorate.Name_Ar))
                .ForMember(dest => dest.District_En, opt => opt.MapFrom(src => src.District.Name_En))
                .ForMember(dest => dest.District_Ar, opt => opt.MapFrom(src => src.District.Name_Ar))
                .ForMember(dest => dest.AccountStatus_En, opt => opt.MapFrom(src => src.AccountStatus.Name_En))
                .ForMember(dest => dest.AccountStatus_ar, opt => opt.MapFrom(src => src.AccountStatus.Name_Ar))
                .ForMember(dest => dest.ApplicationRole_En, opt => opt.MapFrom(src => src.ApplicationRole.Name))
                .ForMember(dest => dest.ApplicationRole_Ar, opt => opt.MapFrom(src => src.ApplicationRole.Name))
                .ForMember(dest => dest.ApplicationRole_ID, opt => opt.MapFrom(src => src.ApplicationRole.Id))
                .ForMember(dest => dest.AvgFeedbackRating, opt => opt.MapFrom(src => src.FeedbackRecievedByMe.Average(fb => fb.Rating)));


            //CreateMap<Appointment, AppointmentResponse>()
            //    .ForMember(dest => dest.AppointmentStatus_En, opt => opt.MapFrom(src => src.AppointmentStatus.Name_En))
            //    .ForMember(dest => dest.AppointmentStatus_Ar, opt => opt.MapFrom(src => src.AppointmentStatus.Name_Ar))
            //    .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FirstName + " " + src.Doctor.LastName))
            //    .ForMember(dest => dest.DoctorSpecialization_En, opt => opt.MapFrom(src => src.Doctor.Specialization.Name_En))
            //    .ForMember(dest => dest.DoctorSpecialization_Ar, opt => opt.MapFrom(src => src.Doctor.Specialization.Name_Ar))
            //    .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FirstName + " " + src.Patient.LastName));

        }
    }
}