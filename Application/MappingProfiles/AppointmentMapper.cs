using Application.Dtos.AppointmentDTO.Request;
using AutoMapper;
using Domain.Entities.AppointmentEntities;

namespace Application.MappingProfiles
{
    public class AppointmentMapper : Profile
    {
        public AppointmentMapper()
        {
            CreateMap<CreateAppointmentRequest, Appointment>();
        }
    }
}