using Domain.Entities.Lookups;
using Domain.Interfaces;
using Domain.Interfaces.CommonInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Lookups
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : LookupController<Gender>
    {
        public GenderController(ILookupService<Gender> baseService, IApiResponseFactory responseFactory) : base(baseService, responseFactory)
        {
        }
    }
}
