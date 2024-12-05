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
            CreateMap<Lookup, LookupResponse>();
            CreateMap<Governorate, GovernorateLookupResponse>();
            CreateMap<Country, CountryLookupResponse>();
            CreateMap<District, DistrictLookupResponse>();


            CreateMap<LookupLookupRequest, Lookup>();
            CreateMap<GovernorateLookupRequest, Governorate>();
            CreateMap<CreateUpdateCountryRequest, Country>();
            CreateMap<DistrictLookupRequest, District>();
        }
    }
}
