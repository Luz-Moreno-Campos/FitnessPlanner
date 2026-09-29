using System.ComponentModel.DataAnnotations;

namespace FitnessPlanner.BLL.DTOs.WorkoutPlans
{
    public class WorkoutPlanUpdateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Difficulty { get; set; } = string.Empty;

        [Range(1, 1000)]
        public int DurationMinutes { get; set; }
    }
}