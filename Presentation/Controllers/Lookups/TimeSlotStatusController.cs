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
    public class TimeSlotStatusController : LookupController<TimeSlotStatus, TimeSlotStatusLookupRequest, TimeSlotStatusLookupResponse>
    {
        public TimeSlotStatusController(ILookupService<TimeSlotStatus, TimeSlotStatusLookupRequest, TimeSlotStatusLookupResponse> lookupService, IApiResponseFactory responseFactory) : base(lookupService, responseFactory)
        {
        }
    }
}
