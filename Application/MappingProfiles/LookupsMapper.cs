using Application.Dtos.Lookup.Request;
using Application.Dtos.Lookup.Response;
using AutoMapper;
using Domain.Entities.Lookups;

namespace Application.MappingProfiles
{
    public class LookupsMapper : Profile
    {
        protected LookupsMapper()
        {
            CreateMap<Lookup, CreateUpdateLookupResponse>();
            CreateMap<Governorate, CreateUpdateGovernorateResponse>();
            CreateMap<Country, CreateUpdateCountryResponse>();
            CreateMap<District, CreateUpdateDistrictResponse>();


            CreateMap<CreateUpdateLookupRequest, Lookup>();
            CreateMap<CreateUpdateGovernorateRequest, Governorate>();
            CreateMap<CreateUpdateCountryRequest, Country>();
            CreateMap<CreateUpdateDistrictRequest, District>();
        }
    }
}
