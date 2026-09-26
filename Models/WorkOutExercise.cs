using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPlanner.Models
{
    public class WorkoutExercise
    {
        public int WorkoutExerciseId { get; set; }

        public int WorkoutPlanId { get; set; }

        public WorkoutPlan WorkoutPlan { get; set; } = null!;

        public int ExerciseId { get; set; }

        public Exercise Exercise { get; set; } = null!;

        public int Sets { get; set; }

        public int Reps { get; set; }

        public decimal WeightKg { get; set; }

        public int RestSeconds { get; set; }
    }
}
