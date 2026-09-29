namespace FitnessPlanner.DTOs.Exercises
{
    public class ExerciseReadDto
    {
        public int ExerciseId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Equipment { get; set; } = string.Empty;
    }
}