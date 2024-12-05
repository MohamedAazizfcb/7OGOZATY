//using Application.Contracts;
//using Domain.Dtos.Auth;
//using Domain.Dtos.User;
//using Microsoft.AspNetCore.Mvc;
//using Presentation.Base;

//namespace Presentation.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {
//        private readonly IAuthService _authService;

//        public AuthController(IAuthService authService)
//        {
//            _authService = authService;
//        }

//        [HttpPost("register")]
//        public async Task<IActionResult> RegisterAsync([FromForm] AddUserRequest request)
//        {
//            var result = await _authService.RegisterAsync(request);
//            return NewResult(result);
//        }
  

//        [HttpPost("login")]
//        public async Task<IActionResult> LoginAsync([FromBody] LoginRquest request)
//        {
//            var result = await _authService.LoginAsync(request);
//            return NewResult(result);
//        }


//    }
//}
