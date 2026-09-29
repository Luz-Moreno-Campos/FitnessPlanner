using FitnessPlanner.DAL.Context;
using FitnessPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlanner.DAL.Repositories
{
    public class UserRepository
    {
        private readonly FitnessPlannerDbContext _context;

        public UserRepository(FitnessPlannerDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Users
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}