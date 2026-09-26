using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPlanner.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool EquipmentRequired { get; set; }

        public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
            = new List<WorkoutExercise>();

        public ICollection<MuscleGroup> MuscleGroups { get; set; }
            = new List<MuscleGroup>();

    }
}