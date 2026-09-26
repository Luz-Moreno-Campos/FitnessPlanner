using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPlanner.Models
{
    public class WorkoutPlan
    {
        public int WorkoutPlanId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Difficulty { get; set; } = string.Empty;

        public int DurationMinutes { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
            = new List<WorkoutExercise>();
    }
}
