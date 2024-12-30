using Application.Interface;
using Core.Models.DataTransferObject;
using Core.Models.DataTransferObject.User;
using Core.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Skillpointis.AI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("userRegistation")]
        public async Task<IActionResult> UserRegistration([FromBody] UserRequestDto userRequest)
        {
            var data = await _userService.CreateUserAsync(userRequest);
            return data != null ? Ok(data) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var data = await _userService.GetAllUserAsync();
            return data != null ? Ok(data) : NotFound();
        }
        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmEmail(string token)
        {
            var user = await _userService.GetUserByTokenAsync(token);
            if (user == null)
            {
                return BadRequest("Invalid token.");
            }
            await _userService.UpdateUserAsync(user);
            return Ok("Email confirmed successfully.");
        }
       
    }
}
