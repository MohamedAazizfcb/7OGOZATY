using Application.Contracts;
using Application.Dtos.TimeSlot;
using Domain.Enums;
using Domain.Interfaces.CommonInterfaces;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotController : ControllerBase
    {
        private readonly IApiResponseFactory _responseFactory;
        private readonly ITimeSlotService _timeSlotService;

        public TimeSlotController(IApiResponseFactory responseFactory, ITimeSlotService timeSlotService)
        {
            _responseFactory = responseFactory;
            _timeSlotService = timeSlotService;
        }


        [HttpPost("CreateNewTimeSlot")]
        public async Task<IActionResult> CreateNewTimeSlot([FromBody] TimeSlotRequest req)
        {
            var result = await _timeSlotService.CreateNewTimeSlot(req);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpPut("UpdateTimeSlotForDoctor/{timeSlotId}")]
        public async Task<IActionResult> UpdateTimeSlotForDoctor([FromBody] TimeSlotRequest request, [FromRoute] int timeSlotId)
        {
            var result = await _timeSlotService.UpdateTimeSlotForDoctor(timeSlotId, request);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpPut("ChangeTimeSlotStatus/{timeSlotId}/{newStatusId}")]
        public async Task<IActionResult> ChangeTimeSlotStatus([FromRoute] int timeSlotId, [FromRoute] int newStatusId)
        {
            var result = await _timeSlotService.ChangeTimeSlotStatus(timeSlotId, newStatusId);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpGet("GetByIdAsync/{timeSlotId}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int timeSlotId)
        {
            var result = await _timeSlotService.GetByIdAsync(timeSlotId);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _timeSlotService.GetAllAsync();
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpPost("GetDoctorSlots")]
        public async Task<IActionResult> GetDoctorSlotsAsync([FromBody] GetDoctorTimeSlostRequest request)
        {
            var result = await _timeSlotService.GetDectorTimeSlots(request);
            return _responseFactory.CreateApiResponse(result);
        }


        [HttpGet("GetSlotAppointment/{timeSlotId}")]
        public async Task<IActionResult> GetSlotAppointment([FromRoute] int timeSlotId)
        {
            var result = await _timeSlotService.GetSlotAppointment(timeSlotId);
            return _responseFactory.CreateApiResponse(result);
        }
    }
}
