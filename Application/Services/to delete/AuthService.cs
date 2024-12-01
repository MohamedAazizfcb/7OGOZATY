//using Application.Contracts;
//using AutoMapper;
//using Domain.Dtos.Auth;
//using Domain.Dtos.User;
//using Domain.Entities.IdentityUser;
//using Domain.Enums;
//using Domain.Results;
//using Domain.Wrappers;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;

//namespace Application.Implementations
//{
//    public class AuthService : ResponseHandler, IAuthService
//    {
//        private readonly UserManager<ApplicationUser> _userManager;

//        private readonly IJwtTokenService _jwtTokenService;
//        private readonly IMapper _mapper;

//        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJwtTokenService jwtTokenService, IMapper mapper)
//        {
//            _userManager = userManager;
//            _jwtTokenService = jwtTokenService;
//            _mapper = mapper;
//        }

//        public async Task<Response<AuthResponse>> LoginAsync(LoginRquest request)
//        {
//            var authResult = new AuthResponse();
//            var user = await _userManager.FindByEmailAsync(request.Email);

//            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
//                return Unauthorized<AuthResponse>();

//            var token = await _jwtTokenService.GenerateTokenAsync(user);
//            authResult = _mapper.Map<AuthResponse>(user);
//            authResult.Token = token;
//            if (authResult.gender.Equals("1"))
//            { 
//                authResult.gender = "Male";
//            }
//            else if (authResult.gender.Equals("2"))
//            {
//                authResult.gender = "Female";
//            }
//            return Success(authResult);
//        }

//        public async Task<Response<AuthResponse>> RegisterAsync(AddUserRequest request)
//        {
//            // Map the user details from the request
//            var user = _mapper.Map<ApplicationUser>(request);
//            user.CreatedAt = DateTime.Now;
//            user.LastLogin = DateTime.Now;
//            user.AccountStatus = AccountStatus.Active;
//            user.UserRole = UserRoles.Patient;

//            // Handle ProfilePicture upload if available
//            if (request.ProfilePicture != null && request.ProfilePicture.Length > 0)
//            {
//                // Define the path where the image will be stored
//                var folderPath = Path.Combine("wwwroot", "uploads", "profile_pictures");
//                var fileName = $"{Guid.NewGuid()}_{request.ProfilePicture.FileName}";
//                var filePath = Path.Combine(folderPath, fileName);

//                // Ensure the folder exists
//                if (!Directory.Exists(folderPath))
//                    Directory.CreateDirectory(folderPath);

//                // Save the file to the server
//                using (var stream = new FileStream(filePath, FileMode.Create))
//                {
//                    await request.ProfilePicture.CopyToAsync(stream);
//                }

//                // Set the ProfilePicture URL
//                user.ProfilePicture = $"/uploads/profile_pictures/{fileName}";
//            }

//            // Create the user
//            var result = await _userManager.CreateAsync(user, request.Password);

//            if (!result.Succeeded)
//                return BadRequest<AuthResponse>(result.Errors.Select(e => e.Description).ToList());

//            // Generate the JWT token and prepare the AuthResponse
//            var authResult = _mapper.Map<AuthResponse>(user);
//            var token = await _jwtTokenService.GenerateTokenAsync(user);
//            authResult.Token = token;
//            return Created(authResult);
//        }

//    }
//}
