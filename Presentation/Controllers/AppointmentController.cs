using Application.Contracts;
using Domain.Dtos.Appointment;
using Microsoft.AspNetCore.Mvc;
using Presentation.Base;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : AppControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddAppointmentRequest request)
        {
            var result = await _appointmentService.Add(request);
            return NewResult(result);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _appointmentService.GetAll();
            return NewResult(result);
        }

        [HttpGet("{appointmentId}/get")]
        public async Task<IActionResult> Get([FromRoute] string appointmentId)
        {
            var result = await _appointmentService.Get(appointmentId);
            return NewResult(result);
        }

        [HttpPut("{appointmentId}/accept")]
        public async Task<IActionResult> AcceptAppointment([FromRoute] string appointmentId)
        {
            var result = await _appointmentService.AcceptAppointment(appointmentId);
            return NewResult(result);
        }

        [HttpPut("{appointmentId}/reject")]
        public async Task<IActionResult> RejectAppointment([FromRoute] string appointmentId)
        {
            var result = await _appointmentService.RejectAppointment(appointmentId);
            return NewResult(result);
        }

        [HttpPut("{appointmentId}/cancel")]
        public async Task<IActionResult> CancelAppointment([FromRoute] string appointmentId)
        {
            var result = await _appointmentService.CancelAppointment(appointmentId);
            return NewResult(result);
        }

        [HttpPut("{appointmentId}/reschedule")]
        public async Task<IActionResult> Reschedule([FromRoute] string appointmentId, [FromBody] RescheduleAppointmentRequest request)
        {
            var result = await _appointmentService.Reschedule(appointmentId, request);
            return NewResult(result);
        }

        [HttpPut("{appointmentId}/changeDoctor")]
        public async Task<IActionResult> ChangeDoctor([FromRoute] string appointmentId, [FromBody] ChangeAppointmentDoctorRequest request)
        {
            var result = await _appointmentService.ChangeDoctor(appointmentId, request);
            return NewResult(result);
        }

    }

}
