using Application.Contracts;
using Application.Implementations;
using Domain.Dtos.Appointment;
using Domain.Dtos.User;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Presentation.Base;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LookupsController : ControllerBase
    {
        private readonly ILookupService _lookupService;

        public LookupsController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        //[HttpPost("addGender")]
        //public async Task<IActionResult> RegisterAsync([FromBody] Gender request)
        //{
        //    var result = await _lookupService.AddGender(request);
        //    return NewResult(result);
        //}

        [HttpGet("genders")]
        public async Task<IActionResult> RegisterAsync()
        {
            var result = await _lookupService.GetGenders();
            return NewResult(result);
        }


    }

}
