using FitnessPlanner.API.Mappings;
using FitnessPlanner.DAL.Repositories;
using FitnessPlanner.BLL.DTOs.Users;

namespace FitnessPlanner.API.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserReadDto>> GetAllAsync(int pageNumber,int pageSize)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 10;
            }

            var users = await _userRepository
                .GetAllAsync(pageNumber, pageSize);

            return users.ToDtoList();
        }

        public async Task<UserReadDto> CreateAsync(UserCreateDto dto)
        {
            var existingUser = await _userRepository
                .GetByEmailAsync(dto.Email);

            if (existingUser != null)
            {
                throw new InvalidOperationException($"A user with email {dto.Email} already exists.");
            }

            var user = dto.ToEntity();

            await _userRepository.AddAsync(user);

            return user.ToDto();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _userRepository
                .GetByIdAsync(id);

            if (user == null)
            {
                throw new KeyNotFoundException( $"User with ID {id} was not found.");
            }

            await _userRepository.DeleteAsync(user);
        }
    }
}