using FitnessPlanner.BLL.DTOs.WorkoutPlans;
using FitnessPlanner.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlanner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutPlansController : ControllerBase
    {
        private readonly WorkoutPlanService _workoutPlanService;

        public WorkoutPlansController(
            WorkoutPlanService workoutPlanService)
        {
            _workoutPlanService = workoutPlanService;
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkoutPlanReadDto>>> GetAll(
            int pageNumber = 1,
            int pageSize = 10)
        {
            var workoutPlans = await _workoutPlanService
                .GetAllAsync(pageNumber, pageSize);

            return Ok(workoutPlans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutPlanReadDto>> GetById(
            int id)
        {
            var workoutPlan = await _workoutPlanService
                .GetByIdAsync(id);

            return Ok(workoutPlan);
        }

        [HttpPost]
        public async Task<ActionResult<WorkoutPlanReadDto>> Create(
            WorkoutPlanCreateDto dto)
        {
            var workoutPlan = await _workoutPlanService
                .CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = workoutPlan.WorkoutPlanId },
                workoutPlan);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WorkoutPlanReadDto>> Update(
            int id,
            WorkoutPlanUpdateDto dto)
        {
            var workoutPlan = await _workoutPlanService.UpdateAsync(id, dto);

            return Ok(workoutPlan);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            int id)
        {
            await _workoutPlanService.DeleteAsync(id);

            return NoContent();
        }
    }
}