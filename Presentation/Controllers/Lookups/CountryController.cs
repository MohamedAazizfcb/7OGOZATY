using Application.Contracts;
using Application.Dtos.Lookup.Request;
using Application.Dtos.Lookup.Response;
using Domain.Entities.Lookups;
using Domain.Interfaces.CommonInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Lookups
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : LookupController<Country, CountryLookupRequest, CountryLookupResponse>
    {
        public CountryController(ILookupService<Country, CountryLookupRequest, CountryLookupResponse> lookupService, IApiResponseFactory responseFactory) : base(lookupService, responseFactory)
        {
        }
    }
}
