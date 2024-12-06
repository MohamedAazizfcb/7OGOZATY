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
    public class AppintmentStatusController : LookupController<AppointmentStatus, AppointmentStatusLookupRequest, AppointmentStatusLookupResponse>
    {
        public AppintmentStatusController(ILookupService<AppointmentStatus, AppointmentStatusLookupRequest, AppointmentStatusLookupResponse> lookupService, IApiResponseFactory responseFactory) : base(lookupService, responseFactory)
        {
        }
    }
}
