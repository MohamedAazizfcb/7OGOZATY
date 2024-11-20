using AutoMapper;
using Domain.Dtos.Appointment;
using Domain.Dtos.Auth;
using Domain.Dtos.User;
using Domain.Entities;
using Domain.Entities.IdentityUser;

namespace Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddUserRequest, ApplicationUser>();
            CreateMap<UpdateUserRequest, ApplicationUser>();
            CreateMap<ApplicationUser, AuthResponse>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
            CreateMap<ApplicationUser, GetUserResponse>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));


            CreateMap<Appointment, GetAppointmentResponse>();
        }
    }
}