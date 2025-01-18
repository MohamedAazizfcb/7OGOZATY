using Application.Contracts.Authentication;
using Domain.Interfaces.CommonInterfaces;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos.Authentication.Request;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentictionController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IApiResponseFactory _responseFactory;

        public AuthentictionController(IAuthenticationService authenticationService, IApiResponseFactory responseFactory)
        {
            _authenticationService = authenticationService;
            _responseFactory = responseFactory;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            var result = await _authenticationService.LoginAsync(req);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpPost("createAdmin")]
        public async Task<IActionResult> CreateAdmin([FromForm] CreateAdminRequest req)
        {
            var result = await _authenticationService.CreateUserAsync(req, Domain.Enums.UserRolesEnum.Admin);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpPost("createDoctor")]
        public async Task<IActionResult> CreateDoctor([FromForm] CreateDoctorRequest req)
        {
            var result = await _authenticationService.CreateUserAsync(req, Domain.Enums.UserRolesEnum.Doctor);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpPost("createPatient")]
        public async Task<IActionResult> CreatePatient([FromForm] CreatePatientRequest req)
        {
            var result = await _authenticationService.CreateUserAsync(req, Domain.Enums.UserRolesEnum.Patient);
            return _responseFactory.CreateApiResponse(result);
        }

        [HttpPost("createSecretary")]
        public async Task<IActionResult> CreateSecretary([FromForm] CreateSecretaryRequest req)
        {
            var result = await _authenticationService.CreateUserAsync(req, Domain.Enums.UserRolesEnum.Secretary);
            return _responseFactory.CreateApiResponse(result);
        }
    }
}
