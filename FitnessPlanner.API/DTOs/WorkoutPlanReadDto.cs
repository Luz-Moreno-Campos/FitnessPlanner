public class WorkoutPlanReadDto
{
    public int WorkoutPlanId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Difficulty { get; set; } = string.Empty;

    public int DurationMinutes { get; set; }

    public int UserId { get; set; }
}