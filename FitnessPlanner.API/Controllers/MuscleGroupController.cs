using FitnessPlanner.BLL.DTOs.MuscleGroups;
using FitnessPlanner.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlanner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuscleGroupsController : ControllerBase
    {
        private readonly MuscleGroupService _muscleGroupService;

        public MuscleGroupsController(MuscleGroupService muscleGroupService)
        {
            _muscleGroupService = muscleGroupService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MuscleGroupReadDto>>> GetAll()
        {
            var muscleGroups = await _muscleGroupService
                .GetAllAsync();

            return Ok(muscleGroups);
        }
    }
}