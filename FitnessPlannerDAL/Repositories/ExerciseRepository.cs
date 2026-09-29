using FitnessPlanner.DAL.Context;
using FitnessPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlanner.DAL.Repositories
{
    public class ExerciseRepository
    {
        private readonly FitnessPlannerDbContext _context;

        public ExerciseRepository(FitnessPlannerDbContext context)
        {
            _context = context;
        }

        public async Task<List<Exercise>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Exercises
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Exercise?> GetByIdAsync(int id)
        {
            return await _context.Exercises
                .FirstOrDefaultAsync(e => e.ExerciseId == id);
        }

        public async Task<Exercise?> GetByNameAsync(string name)
        {
            return await _context.Exercises
                .FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<List<Exercise>> SearchAsync(
            string? muscleGroup,
            string? equipment,
            int pageNumber,
            int pageSize)
        {
            var exercises = await _context.Exercises
                .Include(e => e.MuscleGroups)
                .ToListAsync();

            if (!string.IsNullOrWhiteSpace(muscleGroup))
            {
                exercises = exercises
                    .Where(e => e.MuscleGroups.Any(
                        mg => mg.Name == muscleGroup))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(equipment))
            {
                exercises = exercises
                    .Where(e => e.Equipment.Contains(equipment))
                    .ToList();
            }

            return exercises
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public async Task AddAsync(Exercise exercise)
        {
            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Exercise exercise)
        {
            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
        }
    }
}