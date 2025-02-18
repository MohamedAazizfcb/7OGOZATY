using Application.AppointmentDTO.Request;
using Application.Contracts;
using Application.Dtos.AppointmentDTO.Request;
using Application.Dtos.DoctorDTO.Request;
using Application.Dtos.DoctorDTO.Response;
using Domain.Enums;
using Domain.Interfaces.CommonInterfaces;
using Microsoft.AspNetCore.Mvc;



namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IApiResponseFactory _responseFactory;
        private readonly IDoctorService _doctorService;

        public DoctorController(IApiResponseFactory responseFactory, IDoctorService doctorService)
        {
            _responseFactory = responseFactory;
            _doctorService = doctorService;
        }

        [HttpPost("addServicesForAppointment")]
        public async Task<IActionResult> AddServicesForAppointment([FromBody] AddServiceToDoctorRequest req)
        {
            var result = await _doctorService.AddServiceToDoctor(req);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpGet("getPendingAppointmentsOfDoctor/{docId}/{date}")]
        public async Task<IActionResult> GetPendingAppointmentsOfDoctor([FromRoute] int docId, [FromRoute] DateOnly date)
        {
            var result = await _doctorService.GetDaySummary(date, docId);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpGet("getDoctorsBySpecializationId/{specializationid}")]
        public async Task<IActionResult> GetDoctorsBySpecializationId([FromRoute] int specializationid)
        {
            var result = await _doctorService.GetDoctorsBySpecializationId(specializationid);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpGet("getOverallTopTenRatedDoctors")]
        public async Task<IActionResult> GetOverallTopTenRatedDoctors()
        {
            var result = await _doctorService.GetOverallTopTenRatedDoctors();
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpPost("getDoctorsByOptionalParams")]
        public async Task<IActionResult> GetDoctorsByOptionalParams([FromBody] GetDoctorsByFilterRequest request)
        {
            var result = await _doctorService.GetDoctorsByOptionalParams(request);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpPost("getDoctorDayAppointmentsCount")]
        public async Task<IActionResult> GetDoctorDayAppointmentsCount([FromBody] DoctorDayAppointmentsCountRequest request)
        {
            var result = await _doctorService.GetDoctorDayAppointmentsCount(request);
            return _responseFactory.CreateApiResponse(result);
        }
    }
}