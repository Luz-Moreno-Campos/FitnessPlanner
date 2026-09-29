using FitnessPlanner.BLL.DTOs.Exercises;
using FitnessPlanner.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlanner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly ExerciseService _exerciseService;

        public ExercisesController(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExerciseReadDto>>> GetAll(
            int pageNumber = 1,
            int pageSize = 10)
        {
            var exercises = await _exerciseService
                .GetAllAsync(pageNumber, pageSize);

            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseReadDto>> GetById(int id)
        {
            var exercise = await _exerciseService.GetByIdAsync(id);

            return Ok(exercise);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<ExerciseReadDto>>> Search(
            string? muscleGroup,
            string? equipment,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var exercises = await _exerciseService
                .SearchAsync(
                    muscleGroup,
                    equipment,
                    pageNumber,
                    pageSize);

            return Ok(exercises);
        }

        [HttpPost]
        public async Task<ActionResult<ExerciseReadDto>> Create(ExerciseCreateDto dto)
        {
            var exercise = await _exerciseService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = exercise.ExerciseId },
                exercise);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ExerciseReadDto>> Update(int id,UpdateExerciseDto dto)
        {
            var exercise = await _exerciseService
                .UpdateAsync(id, dto);

            return Ok(exercise);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _exerciseService
                .DeleteAsync(id);

            return NoContent();
        }
    }
}