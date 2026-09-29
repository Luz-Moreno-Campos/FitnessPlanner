using FitnessPlanner.DTOs.Exercises;
using FitnessPlanner.Models;

namespace FitnessPlanner.API.Mappings
{
    public static class ExerciseMappings
    {
        public static ExerciseReadDto ToDto(this Exercise exercise)
        {
            return new ExerciseReadDto
            {
                ExerciseId = exercise.ExerciseId,
                Name = exercise.Name,
                Description = exercise.Description,
                Equipment = exercise.Equipment
            };
        }

        public static Exercise ToEntity(this ExerciseCreateDto dto)
        {
            return new Exercise
            {
                Name = dto.Name,
                Description = dto.Description,
                Equipment = dto.Equipment
            };
        }

        public static void UpdateFromDto(this Exercise exercise,UpdateExerciseDto updateDto)
        {
            exercise.Name = updateDto.Name;
            exercise.Description = updateDto.Description;
            exercise.Equipment = updateDto.Equipment;
        }

        public static List<ExerciseReadDto> ToDtoList(this IEnumerable<Exercise> exercises)
        {
            return exercises
                .Select(e => e.ToDto())
                .ToList();
        }
    }
}