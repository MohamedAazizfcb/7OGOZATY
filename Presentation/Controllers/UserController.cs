using Application.Contracts;
using Domain.Dtos.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Base;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] AddUserRequest request)
        {
            var result = _userService.Add(request);
            return NewResult(result);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            return NewResult(result);
        }

        [HttpGet("{id}/get")]
        public IActionResult Get(int id)
        {
            var result = _userService.Get(id);
            return NewResult(result);
        }

        [HttpPut("{id}/update")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateUserRequest request)
        {
            var result = _userService.Update(id, request);
            return NewResult(result);
        }
    }
}
