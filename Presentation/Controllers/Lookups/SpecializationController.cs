using Application.Contracts.Lookups;
using Application.Dtos.Lookup.Request;
using Application.Dtos.Lookup.Response;
using Domain.Entities.Lookups;
using Domain.Interfaces.CommonInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Lookups
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : LookupController<Specialization, SpecializationLookupRequest, SpecializationLookupResponse>
    {
        public SpecializationController(ILookupService<Specialization, SpecializationLookupRequest, SpecializationLookupResponse> lookupService, IApiResponseFactory responseFactory) : base(lookupService, responseFactory)
        {
        }
    }
}
