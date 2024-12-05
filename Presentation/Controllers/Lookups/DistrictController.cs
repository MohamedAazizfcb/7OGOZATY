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
    public class DistrictController : LookupController<District, DistrictLookupRequest, DistrictLookupResponse>
    {
        public DistrictController(ILookupService<District, DistrictLookupRequest, DistrictLookupResponse> lookupService, IApiResponseFactory responseFactory) : base(lookupService, responseFactory)
        {
        }
    }
}
