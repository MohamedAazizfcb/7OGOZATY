using Application.Contracts;
using Domain.Dtos.Auth;
using Domain.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Presentation.Base;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : AppControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("{doctorId}/getAllSlots/{date}")]
        public async Task<IActionResult> getAllSlots([FromRoute] string doctorId, [FromRoute] DateTime date)
        {
            var result = await _doctorService.GetDrSlotsByDate(doctorId, date);
            return NewResult(result);
        }

        [HttpPost("{doctorId}/addSlot/{date}")]
        public async Task<IActionResult> AddSlotForDoctor([FromRoute] string doctorId, [FromRoute] DateTime date)
        {
            var result = await _doctorService.AddSlotForDoctor(doctorId, date);
            return NewResult(result);
        }
    }
}
