using Application.Dtos.Authentication;
using Application.Dtos.Lookup.Request;
using Application.Dtos.Lookup.Response;
using Application.Dtos.User;
using AutoMapper;
using Domain.Entities.Lookups;
using Domain.Entities.User;

namespace Application.MappingProfiles
{
    public class LookupMapper : Profile
    {
        public LookupMapper()
        {
            CreateMap<CreateDoctorRequest, Doctor>();
            CreateMap<CreatePatientRequest , Patient>();
            CreateMap<CreateSecretaryRequest, Secretary>();
        }
    }
}