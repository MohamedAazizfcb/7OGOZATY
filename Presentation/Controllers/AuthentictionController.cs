using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentictionController : ControllerBase
    {
        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] string doctorId)
        //{
        //    var result = await _doctorService.GetDrSlotsByDate(doctorId, date);
        //    return NewResult(result);
        //}

        //[HttpGet("{doctorId}/getAllSlots/{date}")]
        //public async Task<IActionResult> getAllSlots([FromRoute] string doctorId, [FromRoute] DateTime date)
        //{
        //    var result = await _doctorService.GetDrSlotsByDate(doctorId, date);
        //    return NewResult(result);
        //}
    }
}
