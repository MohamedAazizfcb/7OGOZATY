using Application.Dtos.Clinic;
using Application.Dtos.SpecializationServices.Request;
using Application.Dtos.SpecializationServices.Response;
using AutoMapper;
using Domain.Entities.ClinicEntity;
using Domain.Entities.Lookups;
using Domain.Entities.SpecializationServicesEntity;

namespace Application.MappingProfiles
{
    public class SpecializationServiceMapper : Profile
    {
        public SpecializationServiceMapper()
        {
            CreateMap<SpecializationServiceRequest, SpecializationService>();

            CreateMap<SpecializationService, SpecializationServiceResponse>();
        }
    }
}