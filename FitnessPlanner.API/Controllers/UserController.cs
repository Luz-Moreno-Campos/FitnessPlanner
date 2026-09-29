using FitnessPlanner.BLL.DTOs.Users;
using FitnessPlanner.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlanner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserReadDto>>> GetAll(
            int pageNumber = 1,
            int pageSize = 10)
        {
            var users = await _userService.GetAllAsync(pageNumber, pageSize);

            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDto>> Create(UserCreateDto dto)
        {
            var user = await _userService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetAll),
                new { id = user.UserId },
                user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);

            return NoContent();
        }
    }
}