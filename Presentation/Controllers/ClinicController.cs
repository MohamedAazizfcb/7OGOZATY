using Application.Contracts;
using Application.Dtos.Clinic;
using Domain.Interfaces.CommonInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IApiResponseFactory _responseFactory;
        private readonly IClinicService _clinicService;

        public ClinicController(IApiResponseFactory responseFactory, IClinicService clinicService)
        {
            _responseFactory = responseFactory;
            _clinicService = clinicService;
        }


        [HttpPost("createClinic")]
        public async Task<IActionResult> CreateClinic([FromForm] ClinicRequest req)
        {
            var result = await _clinicService.CreateAsync(req);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpPut("updateClinic/{id}")]
        public async Task<IActionResult> UpdateClinic([FromForm] ClinicRequest req, [FromRoute] int id)
        {
            var result = await _clinicService.UpdateAsync(id, req);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpGet("getAllClinics")]
        public async Task<IActionResult> GetAllClinics()
        {
            var result = await _clinicService.GetAllAsync();
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpGet("getClinic/{id}")]
        public async Task<IActionResult> GetClinicById([FromRoute] int id)
        {
            var result = await _clinicService.GetByIdAsync(id);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpGet("getClinicDoctors/{id}")]
        public async Task<IActionResult> GetClinicDoctors([FromRoute] int id)
        {
            var result = await _clinicService.GetClinicDoctors(id);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpGet("getClinicAppointments/{id}")]
        public async Task<IActionResult> GetClinicAppointments([FromRoute] int id)
        {
            var result = await _clinicService.GetClinicAppointments(id);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpDelete("deleteClinic/{id}")]
        public async Task<IActionResult> DeleteClinic([FromRoute] int id)
        {
            var result = await _clinicService.DeleteAsync(id);
            return _responseFactory.CreateApiResponse(result);
        }
    }
}
