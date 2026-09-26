using FitnessPlanner.Models;
using FitnessPlanner.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlanner.DAL.Seed
{
    public static class SeedData
    {
        public static async Task InitializeAsync(FitnessPlannerDbContext context)
        {
            if (await context.Users.AnyAsync())
            {
                return;
            }

            // Muscle Groups

            var chest = new MuscleGroup { Name = "Chest" };
            var back = new MuscleGroup { Name = "Back" };
            var legs = new MuscleGroup { Name = "Legs" };
            var shoulders = new MuscleGroup { Name = "Shoulders" };
            var biceps = new MuscleGroup { Name = "Biceps" };
            var triceps = new MuscleGroup { Name = "Triceps" };
            var core = new MuscleGroup { Name = "Core" };
            var glutes = new MuscleGroup { Name = "Glutes" };

            await context.MuscleGroups.AddRangeAsync(
                chest,
                back,
                legs,
                shoulders,
                biceps,
                triceps,
                core,
                glutes);

            // Exercises
            // Exercises

            var benchPress = new Exercise
            {
                Name = "Bench Press",
                Description = "Barbell chest press",
                Equipment = "Barbell and Bench"
            };

            var pushUp = new Exercise
            {
                Name = "Push Up",
                Description = "Bodyweight pushing exercise",
                Equipment = "None"
            };

            var pullUp = new Exercise
            {
                Name = "Pull Up",
                Description = "Upper body pulling exercise",
                Equipment = "Pull-Up Bar"
            };

            var squat = new Exercise
            {
                Name = "Squat",
                Description = "Lower body compound movement",
                Equipment = "Barbell"
            };

            var deadlift = new Exercise
            {
                Name = "Deadlift",
                Description = "Posterior chain compound movement",
                Equipment = "Barbell"
            };

            var shoulderPress = new Exercise
            {
                Name = "Shoulder Press",
                Description = "Overhead pressing movement",
                Equipment = "Dumbbells"
            };

            var bicepCurl = new Exercise
            {
                Name = "Bicep Curl",
                Description = "Bicep isolation exercise",
                Equipment = "Dumbbells"
            };

            var plank = new Exercise
            {
                Name = "Plank",
                Description = "Core stabilization exercise",
                Equipment = "None"
            };

            // Many-to-Many relationships

            benchPress.MuscleGroups.Add(chest);
            benchPress.MuscleGroups.Add(shoulders);
            benchPress.MuscleGroups.Add(triceps);

            pushUp.MuscleGroups.Add(chest);
            pushUp.MuscleGroups.Add(shoulders);
            pushUp.MuscleGroups.Add(triceps);

            pullUp.MuscleGroups.Add(back);
            pullUp.MuscleGroups.Add(biceps);

            squat.MuscleGroups.Add(legs);
            squat.MuscleGroups.Add(glutes);

            deadlift.MuscleGroups.Add(back);
            deadlift.MuscleGroups.Add(glutes);

            shoulderPress.MuscleGroups.Add(shoulders);
            shoulderPress.MuscleGroups.Add(triceps);

            bicepCurl.MuscleGroups.Add(biceps);

            plank.MuscleGroups.Add(core);

            await context.Exercises.AddRangeAsync(
                benchPress,
                pushUp,
                pullUp,
                squat,
                deadlift,
                shoulderPress,
                bicepCurl,
                plank);

            // Users

            var john = new User
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "john.smith@email.com"
            };

            var sarah = new User
            {
                FirstName = "Sarah",
                LastName = "Johnson",
                Email = "sarah.johnson@email.com"
            };

            await context.Users.AddRangeAsync(john, sarah);

            // Workout Plans

            var beginnerPlan = new WorkoutPlan
            {
                Title = "Beginner Full Body",
                Difficulty = "Beginner",
                DurationMinutes = 45,
                User = john
            };

            var upperBodyPlan = new WorkoutPlan
            {
                Title = "Upper Body Strength",
                Difficulty = "Intermediate",
                DurationMinutes = 60,
                User = sarah
            };

            var lowerBodyPlan = new WorkoutPlan
            {
                Title = "Lower Body Power",
                Difficulty = "Intermediate",
                DurationMinutes = 50,
                User = john
            };

            await context.WorkoutPlans.AddRangeAsync(
                beginnerPlan,
                upperBodyPlan,
                lowerBodyPlan);

            await context.SaveChangesAsync();

            // Workout Exercises

            await context.WorkoutExercises.AddRangeAsync(

                new WorkoutExercise
                {
                    WorkoutPlanId = beginnerPlan.WorkoutPlanId,
                    ExerciseId = pushUp.ExerciseId,
                    Sets = 3,
                    Reps = 12,
                    WeightKg = 0,
                    RestSeconds = 60
                },

                new WorkoutExercise
                {
                    WorkoutPlanId = beginnerPlan.WorkoutPlanId,
                    ExerciseId = squat.ExerciseId,
                    Sets = 3,
                    Reps = 15,
                    WeightKg = 20,
                    RestSeconds = 60
                },

                new WorkoutExercise
                {
                    WorkoutPlanId = upperBodyPlan.WorkoutPlanId,
                    ExerciseId = benchPress.ExerciseId,
                    Sets = 4,
                    Reps = 8,
                    WeightKg = 60,
                    RestSeconds = 90
                },

                new WorkoutExercise
                {
                    WorkoutPlanId = upperBodyPlan.WorkoutPlanId,
                    ExerciseId = pullUp.ExerciseId,
                    Sets = 4,
                    Reps = 10,
                    WeightKg = 0,
                    RestSeconds = 90
                },

                new WorkoutExercise
                {
                    WorkoutPlanId = lowerBodyPlan.WorkoutPlanId,
                    ExerciseId = squat.ExerciseId,
                    Sets = 4,
                    Reps = 10,
                    WeightKg = 70,
                    RestSeconds = 120
                },

                new WorkoutExercise
                {
                    WorkoutPlanId = lowerBodyPlan.WorkoutPlanId,
                    ExerciseId = deadlift.ExerciseId,
                    Sets = 4,
                    Reps = 6,
                    WeightKg = 90,
                    RestSeconds = 120
                });

            await context.SaveChangesAsync();
        }
    }
}