using FitnessPlanner.Models;
using Microsoft.EntityFrameworkCore;



namespace FitnessPlanner.DAL.Context
{
    public class FitnessPlannerDbContext : DbContext
    {
        public FitnessPlannerDbContext(DbContextOptions<FitnessPlannerDbContext> options): base(options)
        {
        }

        // DbSets

        public DbSet<User> Users { get; set; }

        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<MuscleGroup> MuscleGroups { get; set; }

        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // PRIMARY KEYS

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<WorkoutPlan>()
                .HasKey(wp => wp.WorkoutPlanId);

            modelBuilder.Entity<Exercise>()
                .HasKey(e => e.ExerciseId);

            modelBuilder.Entity<MuscleGroup>()
                .HasKey(mg => mg.MuscleGroupId);

            modelBuilder.Entity<WorkoutExercise>()
                .HasKey(we => we.WorkoutExerciseId);


            // PROPERTIES AND CONSTRAINTS

            // User

            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();


            // WorkoutPlan

            modelBuilder.Entity<WorkoutPlan>()
                .Property(wp => wp.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<WorkoutPlan>()
                .Property(wp => wp.Difficulty)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<WorkoutPlan>()
                .Property(wp => wp.DurationMinutes)
                .IsRequired();


            // Exercise

            modelBuilder.Entity<Exercise>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Exercise>()
                .Property(e => e.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<Exercise>()
                .Property(e => e.Equipment)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Exercise>()
                .HasIndex(e => e.Name)
                .IsUnique();


            // MuscleGroup

            modelBuilder.Entity<MuscleGroup>()
                .Property(mg => mg.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<MuscleGroup>()
                .HasIndex(mg => mg.Name)
                .IsUnique();


            // WorkoutExercise

            modelBuilder.Entity<WorkoutExercise>()
                .Property(we => we.Sets)
                .IsRequired();

            modelBuilder.Entity<WorkoutExercise>()
                .Property(we => we.Reps)
                .IsRequired();

            modelBuilder.Entity<WorkoutExercise>()
                .Property(we => we.WeightKg)
                .HasPrecision(6, 2)
                .IsRequired();

            modelBuilder.Entity<WorkoutExercise>()
                .Property(we => we.RestSeconds)
                .IsRequired();


            // This prevents duplicate exercises inside the same workout plan

            modelBuilder.Entity<WorkoutExercise>()
                .HasIndex(we => new { we.WorkoutPlanId, we.ExerciseId })
                .IsUnique();


            // RELATIONSHIPS

            // USER (1:N) WORKOUT PLAN

            modelBuilder.Entity<WorkoutPlan>()
                .HasOne(wp => wp.User)
                .WithMany(u => u.WorkoutPlans)
                .HasForeignKey(wp => wp.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            // WORKOUT PLAN (1:N) WORKOUT EXERCISE

            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.WorkoutPlan)
                .WithMany(wp => wp.WorkoutExercises)
                .HasForeignKey(we => we.WorkoutPlanId)
                .OnDelete(DeleteBehavior.Cascade);


            // EXERCISE (1:N) WORKOUT EXERCISE

            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.Exercise)
                .WithMany(e => e.WorkoutExercises)
                .HasForeignKey(we => we.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);


            // EXERCISE (N:N) MUSCLE GROUP

            modelBuilder.Entity<Exercise>()
                .HasMany(e => e.MuscleGroups)
                .WithMany(mg => mg.Exercises);
        }
    }
}