using Application.Contracts;
using Application.Dtos.AppointmentDTO.Request;
using Application.Dtos.Clinic;
using Application.Services;
using Domain.Interfaces.CommonInterfaces;
using Domain.Permissions;
using Domain.Permissions.PermissionsCategories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IApiResponseFactory _responseFactory;
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IApiResponseFactory responseFactory, IAppointmentService appointmentService)
        {
            _responseFactory = responseFactory;
            _appointmentService = appointmentService;
        }


        [HttpPost("createAppointment")]
        public async Task<IActionResult> CreateAppointment([FromForm] CreateAppointmentRequest req)
        {
            var result = await _appointmentService.CreateAsync(req);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpPut("deleteAppointment/{id}")]
        public async Task<IActionResult> DeleteAppointment([FromRoute] int id)
        {
            var result = await _appointmentService.DeleteAsync(id);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpGet("getAllAppointments")]
        public async Task<IActionResult> GetAllAppointments()
        {
            var result = await _appointmentService.GetAll();
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpGet("getAppointment/{id}")]
        public async Task<IActionResult> GetAppointmentById([FromRoute] int id)
        {
            var result = await _appointmentService.GetById(id);
            return _responseFactory.CreateApiResponse(result);
        }

        //[HttpGet("getClinicDoctors/{id}")]
        //public async Task<IActionResult> GetClinicDoctors([FromRoute] int id)
        //{
        //    var result = await _appointmentService.GetClinicDoctors(id);
        //    return _responseFactory.CreateApiResponse(result);
        //}

        //[HttpGet("getClinicAppointments/{id}")]
        //public async Task<IActionResult> GetClinicAppointments([FromRoute] int id)
        //{
        //    var result = await _appointmentService.GetClinicAppointments(id);
        //    return _responseFactory.CreateApiResponse(result);
        //}

        //[HttpDelete("deleteClinic/{id}")]
        //public async Task<IActionResult> DeleteClinic([FromRoute] int id)
        //{
        //    var result = await _appointmentService.DeleteAsync(id);
        //    return _responseFactory.CreateApiResponse(result);
        //}
    }
}
