using Application.Dtos.Lookup.Request;
using Application.Dtos.Lookup.Response;
using AutoMapper;
using Domain.Entities.Lookups;

namespace Application.MappingProfiles
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<AccountStatus, AccountStatusLookupResponse>();
            CreateMap<AppointmentStatus, AppointmentStatusLookupResponse>();
            CreateMap<Country, CountryLookupResponse>();
            CreateMap<District, DistrictLookupResponse>();
            CreateMap<Gender, GenderLookupResponse>();
            CreateMap<Governorate, GovernorateLookupResponse>();
            CreateMap<Specialization, SpecializationLookupResponse>();
            CreateMap<TimeSlotStatus, TimeSlotStatusLookupResponse>();


            CreateMap<AccountStatusLookupRequest, AccountStatus>();
            CreateMap<AppointmentStatusLookupRequest, AppointmentStatus>();
            CreateMap<CountryLookupRequest, Country>();
            CreateMap<DistrictLookupRequest, District>();
            CreateMap<GenderLookupRequest, Gender>();
            CreateMap<GovernorateLookupRequest, Governorate>();
            CreateMap<SpecializationLookupRequest, Specialization>();
            CreateMap<TimeSlotStatusLookupRequest, TimeSlotStatus>();

        }
    }
}