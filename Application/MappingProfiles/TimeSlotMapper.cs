using Application.Dtos.TimeSlot;
using AutoMapper;
using Domain.Entities.TimeSlotEntity;

namespace Application.MappingProfiles
{
    public class TimeSlotMapper : Profile
    {
        public TimeSlotMapper()
        {
            CreateMap<TimeSlotRequest, TimeSlot>();
            CreateMap<TimeSlot, TimeSlotResponse>()
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.Doctor.Id));
        }
    }
}