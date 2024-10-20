using clinic_management_system.Common;
using clinic_management_system.Dtos;
using clinic_management_system.Models;
using clinic_management_system.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clinic_management_system.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService<UserDto> _userService;

        public UserController(IService<UserDto> userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.FetchAllAsync();
            return Ok(new ApiResponse<IEnumerable<UserDto>>(true, "Users retrieved successfully", users));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.FetchByIdAsync(id);
            return Ok(new ApiResponse<UserDto>(true, "User retrieved successfully", user));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _userService.AddAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto user, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != user.UserId) return BadRequest("Id mismatch");

            await _userService.UpdateAsync(id, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
