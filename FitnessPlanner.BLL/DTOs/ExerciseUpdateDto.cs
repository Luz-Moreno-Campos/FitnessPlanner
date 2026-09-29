using System.ComponentModel.DataAnnotations;

namespace FitnessPlanner.BLL.DTOs.Exercises
{
    public class UpdateExerciseDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Equipment { get; set; } = string.Empty;
    }
}
