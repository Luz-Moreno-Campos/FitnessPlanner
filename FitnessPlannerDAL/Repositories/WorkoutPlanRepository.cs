using FitnessPlanner.DAL.Context;
using FitnessPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlanner.DAL.Repositories
{
    public class WorkoutPlanRepository
    {
        private readonly FitnessPlannerDbContext _context;

        public WorkoutPlanRepository(FitnessPlannerDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkoutPlan>> GetAllAsync()
        {
            return await _context.WorkoutPlans.ToListAsync();
        }

        public async Task<WorkoutPlan?> GetByIdAsync(int id)
        {
            return await _context.WorkoutPlans
                .FirstOrDefaultAsync(wp => wp.WorkoutPlanId == id);
        }

        public async Task AddAsync(WorkoutPlan workoutPlan)
        {
            await _context.WorkoutPlans.AddAsync(workoutPlan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(WorkoutPlan workoutPlan)
        {
            _context.WorkoutPlans.Remove(workoutPlan);
            await _context.SaveChangesAsync();
        }
    }
}