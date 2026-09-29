using FitnessPlanner.BLL.DTOs.WorkoutPlans;
using FitnessPlanner.Models;

namespace FitnessPlanner.API.Mappings
{
    public static class WorkoutPlanMappings
    {
        public static WorkoutPlanReadDto ToDto(this WorkoutPlan workoutPlan)
        {
            return new WorkoutPlanReadDto
            {
                WorkoutPlanId = workoutPlan.WorkoutPlanId,
                Title = workoutPlan.Title,
                Difficulty = workoutPlan.Difficulty,
                DurationMinutes = workoutPlan.DurationMinutes,
                UserId = workoutPlan.UserId
            };
        }

        public static WorkoutPlan ToEntity(this WorkoutPlanCreateDto dto)
        {
            return new WorkoutPlan
            {
                Title = dto.Title,
                Difficulty = dto.Difficulty,
                DurationMinutes = dto.DurationMinutes,
                UserId = dto.UserId
            };
        }

        public static void UpdateFromDto(this WorkoutPlan workoutPlan, WorkoutPlanUpdateDto dto)

        {
            workoutPlan.Title = dto.Title;
            workoutPlan.Difficulty = dto.Difficulty;
            workoutPlan.DurationMinutes = dto.DurationMinutes;
        }

        public static List<WorkoutPlanReadDto> ToDtoList(this IEnumerable<WorkoutPlan> workoutPlans)

        {
            return workoutPlans
                .Select(wp => wp.ToDto())
                .ToList();
        }
    }
}