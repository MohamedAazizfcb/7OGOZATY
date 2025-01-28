using Application.Dtos.AppointmentDTO.Request;
using Application.Dtos.AppointmentDTO.Response;
using AutoMapper;
using Domain.Entities.AppointmentEntities;

namespace Application.MappingProfiles
{
    public class AppointmentMapper : Profile
    {
        public AppointmentMapper()
        {
            CreateMap<CreateAppointmentRequest, Appointment>();
            CreateMap<Appointment, AppointmentResponse>()
                .ForMember(dest => dest.AppointmentStatus_En, opt => opt.MapFrom(src => src.AppointmentStatus.Name_En))
                .ForMember(dest => dest.AppointmentStatus_Ar, opt => opt.MapFrom(src => src.AppointmentStatus.Name_Ar))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FirstName + " " + src.Doctor.LastName))
                .ForMember(dest => dest.DoctorSpecialization_En, opt => opt.MapFrom(src => src.Doctor.Specialization.Name_En))
                .ForMember(dest => dest.DoctorSpecialization_Ar, opt => opt.MapFrom(src => src.Doctor.Specialization.Name_Ar))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FirstName + " " + src.Patient.LastName));

        }
    }
}