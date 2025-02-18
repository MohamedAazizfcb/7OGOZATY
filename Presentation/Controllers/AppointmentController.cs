using Application.AppointmentDTO.Request;
using Application.Contracts;
using Application.Dtos.AppointmentDTO.Request;
using Application.Dtos.Clinic;
using Application.Services;
using Domain.Entities.TimeSlotEntity;
using Domain.Enums;
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
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentRequest req)
        {
            var result = await _appointmentService.CreateAsync(req);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpDelete("deleteAppointment/{id}")]
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

        [HttpPost("rescheduleSingleAppointment")]
        public async Task<IActionResult> RescheduleSingleAppointment([FromBody] RescheduleSingleAppointmentRequest request)
        {
            var result = await _appointmentService.RescheduleAppointment(request);
            return _responseFactory.CreateApiResponse(result);
        }


        [HttpPost("rescheduleDayOfAppointment")]
        public async Task<IActionResult> RescheduleDayOfAppointment([FromBody] RescheduleDayOfAppointmentsRequest request)
        {
            var result = await _appointmentService.RescheduleDayOfAppointments(request);
            return _responseFactory.CreateApiResponse(result);
        }


        //[HttpPut("apporoveAppointment/{id}")]
        //public async Task<IActionResult> ApproveAppointment([FromRoute] int id)
        //{
        //    var result = await _appointmentService.ChangeAppointmentStatus(id, (int)AppointmentStatusEnum.Accepted);
        //    return _responseFactory.CreateApiResponse(result);
        //}

        //[HttpPut("rejectAppointment/{id}")]
        //public async Task<IActionResult> RejectAppointment([FromRoute] int id)
        //{
        //    var result = await _appointmentService.ChangeAppointmentStatus(id, (int)AppointmentStatusEnum.Rejected);
        //    return _responseFactory.CreateApiResponse(result);
        //}


        [HttpPut("cancelAppointment/{id}")]
        public async Task<IActionResult> CancelAppointment([FromRoute] int id)
        {
            var result = await _appointmentService.ChangeAppointmentStatus(id, (int)AppointmentStatusEnum.Cancelled);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpPut("makeAppointmentArrived/{id}")]
        public async Task<IActionResult> MakeAppointmentArrived([FromRoute] int id)
        {
            var result = await _appointmentService.ChangeAppointmentStatus(id, (int)AppointmentStatusEnum.Arrived);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpPut("makeAppointmentNextInQueue/{id}")]
        public async Task<IActionResult> MakeAppointmentNextInQueue([FromRoute] int id)
        {
            var result = await _appointmentService.ChangeAppointmentStatus(id, (int)AppointmentStatusEnum.NextInQueue);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpPut("startProgressingTheAppointment/{id}")]
        public async Task<IActionResult> StartProgressingTheAppointment([FromRoute] int id)
        {
            var result = await _appointmentService.ChangeAppointmentStatus(id, (int)AppointmentStatusEnum.InProgress);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpPut("makeAppointmentProccessed/{id}")]
        public async Task<IActionResult> MakeAppointmentProccessed([FromRoute] int id)
        {
            var result = await _appointmentService.ChangeAppointmentStatus(id, (int)AppointmentStatusEnum.Proccessed);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpPost("SearchForAppointmentsByOptionalParams")]
        public async Task<IActionResult> SearchForAppointments([FromBody] SearchAppointmentsRequest request)
        {
            var result = await _appointmentService.SearchForAppointments(request);
            return _responseFactory.CreateApiResponse(result);
        }


        [HttpPost("addServiceForAppointment")]
        public async Task<IActionResult> addServicesForAppointment([FromBody] AddServiceForAppointmentRequest req)
        {
            var result = await _appointmentService.AddServiceForAppointment(req);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpGet("getPendingAppointmentsOfDoctor/{docId}")]
        public async Task<IActionResult> GetPendingAppointmentsOfDoctor([FromRoute] int docId)
        {
            var result = await _appointmentService.GetPendingAppointmentsOfDoctor(docId);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpGet("getAppointmentServices/{appointmentId}")]
        public async Task<IActionResult> GetAppointmentServices([FromRoute] int appointmentId)
        {
            var result = await _appointmentService.GetAppointmentServices(appointmentId);
            return _responseFactory.CreateApiResponse(result);
        }

    }
}
