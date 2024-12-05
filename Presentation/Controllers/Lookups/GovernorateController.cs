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
    public class GovernorateController : LookupController<Governorate, GovernorateLookupRequest, GovernorateLookupResponse>
    {
        public GovernorateController(ILookupService<Governorate, GovernorateLookupRequest, GovernorateLookupResponse> lookupService, IApiResponseFactory responseFactory) : base(lookupService, responseFactory)
        {
        }
    }
}
