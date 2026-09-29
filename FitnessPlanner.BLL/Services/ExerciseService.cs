using FitnessPlanner.DAL.Repositories;
using FitnessPlanner.BLL.DTOs.Exercises;
using FitnessPlanner.BLL.Mappings;


namespace FitnessPlanner.BLL.Services
{
    public class ExerciseService
    {
        private readonly ExerciseRepository _exerciseRepository;

        public ExerciseService(ExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<List<ExerciseReadDto>> GetAllAsync(int pageNumber,int pageSize)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 10;
            }

            var exercises = await _exerciseRepository.GetAllAsync(pageNumber, pageSize);

            return exercises.ToDtoList();
        }

        public async Task<ExerciseReadDto> GetByIdAsync(int id)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(id);

            if (exercise == null)
            {
                throw new KeyNotFoundException(
                    $"Exercise with ID {id} was not found.");
            }

            return exercise.ToDto();
        }

        public async Task<ExerciseReadDto> CreateAsync(ExerciseCreateDto dto)
        {
            var existingExercise = await _exerciseRepository.GetByNameAsync(dto.Name);

            if (existingExercise != null)
            {
                throw new InvalidOperationException( $"Exercise with name {dto.Name} already exists.");
            }

            var exercise = dto.ToEntity();

            await _exerciseRepository.AddAsync(exercise);

            return exercise.ToDto();
        }

        public async Task UpdateAsync(int id,UpdateExerciseDto dto)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(id);

            if (exercise == null)
            {
                throw new KeyNotFoundException($"Exercise with ID {id} was not found.");
            }

            exercise.UpdateFromDto(dto);

            await _exerciseRepository.UpdateAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(id);

            if (exercise == null)
            {
                throw new KeyNotFoundException($"Exercise with ID {id} was not found.");
            }

            await _exerciseRepository.DeleteAsync(exercise);
        }

        public async Task<List<ExerciseReadDto>> SearchAsync(
            string? muscleGroup,
            string? equipment,
            int pageNumber,
            int pageSize)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 10;
            }

            var exercises = await _exerciseRepository
                .SearchAsync(
                    muscleGroup,
                    equipment,
                    pageNumber,
                    pageSize);

            return exercises.ToDtoList();
        }
    }
}