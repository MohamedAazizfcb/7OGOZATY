using Application.Contracts;
using AutoMapper;
using Domain.Dtos.Auth;
using Domain.Dtos.User;
using Domain.Entities;
using Domain.Enums;
using Domain.Results;
using Domain.Wrappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Implementations
{
    public class AuthService : ResponseHandler, IAuthService
    {
        private readonly UserManager<User> _userManager;

        private readonly IJwtTokenService _jwtTokenService;
        private readonly IMapper _mapper;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IJwtTokenService jwtTokenService, IMapper mapper)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
            _mapper = mapper;
        }

        public async Task<Response<AuthResponse>> LoginAsync(LoginRquest request)
        {
            var authResult = new AuthResponse();
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
                return Unauthorized<AuthResponse>();

            var token = await _jwtTokenService.GenerateTokenAsync(user);
            authResult = _mapper.Map<AuthResponse>(user);
            authResult.Token = token;           
            return Success(authResult);
        }

        public async Task<Response<AuthResponse>> RegisterAsync(AddUserRequest request)
        {
            var user = _mapper.Map<User>(request);
            user.CreatedAt = DateTime.Now;
            user.LastLogin = DateTime.Now;
            user.AccountStatus = AccountStatus.Active;
            user.UserRole = UserRole.Patient;

            var result = await _userManager.CreateAsync(user, request.Password);


            if (!result.Succeeded)
                return BadRequest<AuthResponse>(result.Errors.Select(e => e.Description).ToList());

            var authResult = new AuthResponse();
            var token = await _jwtTokenService.GenerateTokenAsync(user);
            authResult = _mapper.Map<AuthResponse>(user);
            authResult.Token = token;
            return Created(authResult);
        }
    }
}
