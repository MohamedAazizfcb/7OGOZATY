using Application.Contracts.Authentication;
using Application.Dtos.Authentication;
using AutoMapper;
using Domain.Entities.User;
using Domain.Enums;
using Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces;
using Domain.Interfaces.UtilityInterfaces.FileHandlerInterfaces;
using Domain.Results;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Authentication
{
    public class AuthentictionService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IJwtTokenService _jwtTokenService;
        private readonly IMapper _mapper;
        private readonly IOperationResultFactory _operationResultFactory;

        private readonly IFileHandler _fileHandler;

        public AuthentictionService(UserManager<ApplicationUser> userManager, IJwtTokenService jwtTokenService, IMapper mapper, IOperationResultFactory operationResultFactory, IFileHandler fileHandler)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
            _mapper = mapper;
            _operationResultFactory = operationResultFactory;
            _fileHandler = fileHandler;
        }

        public async Task<OperationResultSingle<string>> CreateDoctorAsync(CreateDoctorRequest request)
        {
            var user = _mapper.Map<Doctor>(request);
            user.AccountStatusId = (int)AccountStatusEnum.Active;
            user.LastLogin = DateTime.Now;
            user.ApplicationRoleId = (int)UserRolesEnum.Doctor;


            // Create the user
            var result = await _userManager.CreateAsync(user, request.Password);
            if (request.ProfilePicture != null && request.ProfilePicture.Length > 0)
            {
                // Define the path where the image will be stored
                var folderPath = Path.Combine("wwwroot", "uploads", "profile_pictures");
                user.ProfilePicture = await _fileHandler.UploadAsync(request.ProfilePicture, folderPath);
            }

            if (!result.Succeeded)
                return _operationResultFactory.BadRequest<string>(result.Errors.Select(e => e.Description).ToList());

            return _operationResultFactory.Created("Success!");
        }

        public async Task<OperationResultSingle<string>> CreatePatientAsync(CreatePatientRequest request)
        {
            var user = _mapper.Map<Patient>(request);
            user.AccountStatusId = (int)AccountStatusEnum.Active;
            user.LastLogin = DateTime.Now;
            user.ApplicationRoleId = (int)UserRolesEnum.Patient;


            // Create the user
            var result = await _userManager.CreateAsync(user, request.Password);
            if (request.ProfilePicture != null && request.ProfilePicture.Length > 0)
            {
                // Define the path where the image will be stored
                var folderPath = Path.Combine("wwwroot", "uploads", "profile_pictures");
                user.ProfilePicture = await _fileHandler.UploadAsync(request.ProfilePicture, folderPath);
            }

            if (!result.Succeeded)
                return _operationResultFactory.BadRequest<string>(result.Errors.Select(e => e.Description).ToList());

            return _operationResultFactory.Created("Success!");
        }

        public async Task<OperationResultSingle<string>> CreateSecretaryAsync(CreateSecretaryRequest request)
        {
            var user = _mapper.Map<Secretary>(request);
            user.AccountStatusId = (int)AccountStatusEnum.Active;
            user.LastLogin = DateTime.Now;
            user.ApplicationRoleId = (int)UserRolesEnum.Secretary;


            // Create the user
            var result = await _userManager.CreateAsync(user, request.Password);

            if (request.ProfilePicture != null && request.ProfilePicture.Length > 0)
            {
                // Define the path where the image will be stored
                var folderPath = Path.Combine("wwwroot", "uploads", "profile_pictures");
                user.ProfilePicture = await _fileHandler.UploadAsync(request.ProfilePicture, folderPath);
            }

            if (!result.Succeeded)
                return _operationResultFactory.BadRequest<string>(result.Errors.Select(e => e.Description).ToList());

            return _operationResultFactory.Created("Success!");
        }

        public async Task<OperationResultSingle<AuthenticationResponse>> LoginAsync(LoginRequest request)
        {
            var authResult = new AuthenticationResponse();
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
                return _operationResultFactory.Unauthorized<AuthenticationResponse>();

            var token = await _jwtTokenService.GenerateTokenAsync(user);
            authResult = _mapper.Map<AuthenticationResponse>(user);
            authResult.Token = token;

            return _operationResultFactory.Success(authResult);
        }

    }
}
