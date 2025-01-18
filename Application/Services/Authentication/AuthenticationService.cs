using Application.Contracts.Authentication;
using Application.Dtos.Authentication;
using Application.Dtos.Authentication.Request;
using Application.Dtos.Authentication.Response;
using Application.Strategies.UserStrategies.CreateNewUserStrategy;
using AutoMapper;
using Domain.Entities.User;
using Domain.Enums;
using Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces;
using Domain.Interfaces.UtilityInterfaces.FileHandlerInterfaces;
using Domain.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Application.Services.Authentication
{
    public class AuthentictionService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IJwtTokenService _jwtTokenService;
        private readonly IMapper _mapper;
        private readonly IOperationResultFactory _operationResultFactory;
        private readonly IFileHandler _fileHandler;

        private readonly CreateNewUserStrategyFactory _createNewUserStrategyFactory;
        public AuthentictionService(UserManager<ApplicationUser> userManager, IJwtTokenService jwtTokenService, IMapper mapper, 
            IOperationResultFactory operationResultFactory, IFileHandler fileHandler, 
            CreateNewUserStrategyFactory createNewUserStrategyFactory)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
            _mapper = mapper;
            _operationResultFactory = operationResultFactory;
            _fileHandler = fileHandler;
            _createNewUserStrategyFactory = createNewUserStrategyFactory;
        }

        public async Task<OperationResultSingle<string>> CreateUserAsync(BaseCreateUserRequest request, UserRolesEnum userRole)
        {
            var strategy = _createNewUserStrategyFactory.GetStrategy(userRole);
            return await strategy.CreateNewUser(request);
        }


        public async Task<OperationResultSingle<AuthenticationResponse>> LoginAsync(LoginRequest request)
        {
            var authResult = new AuthenticationResponse();
            var user = await _userManager.Users
                             .Include(u => u.Gender)
                             .Include(u => u.Country)
                             .Include(u => u.Governorate)
                             .Include(u => u.District)
                             .Include(u => u.AccountStatus)
                             .Include(u => u.ApplicationRole)
                             .FirstOrDefaultAsync(u => u.Email == request.EmailOrUsernameOrPhone
                                                       || u.UserName == request.EmailOrUsernameOrPhone 
                                                       || u.PhoneNumber == request.EmailOrUsernameOrPhone);

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
                return _operationResultFactory.Unauthorized<AuthenticationResponse>();

            var token = await _jwtTokenService.GenerateTokenAsync(user);
            authResult = _mapper.Map<AuthenticationResponse>(user);
            authResult.Token = token;

            return _operationResultFactory.Success(authResult);
        }
    }
}
