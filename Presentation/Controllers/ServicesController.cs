using Application.AppointmentDTO.Request;
using Application.Contracts;
using Application.Dtos.AppointmentDTO.Request;
using Application.Dtos.Clinic;
using Application.Dtos.SpecializationServices.Request;
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
    public class ServicesController : ControllerBase
    {
        private readonly IApiResponseFactory _responseFactory;
        private readonly ISpecializationServicesService _specializationServicesService;

        public ServicesController(IApiResponseFactory responseFactory, ISpecializationServicesService specializationServicesService)
        {
            _responseFactory = responseFactory;
            _specializationServicesService = specializationServicesService;
        }

        [HttpPost("createService")]
        public async Task<IActionResult> createService([FromBody] SpecializationServiceRequest req)
        {
            var result = await _specializationServicesService.CreateAsync(req);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpDelete("deleteService/{id}")]
        public async Task<IActionResult> DeleteService([FromRoute] int id)
        {
            var result = await _specializationServicesService.DeleteAsync(id);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpGet("getAllServices")]
        public async Task<IActionResult> GetAllServices()
        {
            var result = await _specializationServicesService.GetAllAsync();
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpGet("getServiceById/{id}")]
        public async Task<IActionResult> GetServiceById([FromRoute] int id)
        {
            var result = await _specializationServicesService.GetByIdAsync(id);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpGet("getServiceBySpecializationId/{specializationid}")]
        public async Task<IActionResult> GetServiceBySpecializationId([FromRoute] int specializationid)
        {
            var result = await _specializationServicesService.GetServiceBySpecializationId(specializationid);
            return _responseFactory.CreateApiResponse(result);
        }

    }
}
