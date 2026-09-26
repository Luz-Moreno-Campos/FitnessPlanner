using FitnessPlanner.DAL.Context;
using FitnessPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlanner.DAL.Repositories
{
    public class MuscleGroupRepository
    {
        private readonly FitnessPlannerDbContext _context;

        public MuscleGroupRepository(FitnessPlannerDbContext context)
        {
            _context = context;
        }

        public async Task<List<MuscleGroup>> GetAllAsync()
        {
            return await _context.MuscleGroups.ToListAsync();
        }
    }
}
