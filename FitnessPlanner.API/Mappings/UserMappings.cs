using FitnessPlanner.DTOs.Users;
using FitnessPlanner.Models;

namespace FitnessPlanner.API.Mappings
{
    public static class UserMappings
    {
        public static UserReadDto ToDto(this User user)
        {
            return new UserReadDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public static User ToEntity(this UserCreateDto dto)
        {
            return new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email
            };
        }

        public static List<UserReadDto> ToDtoList(this IEnumerable<User> users)
        {
            return users.Select(u => u.ToDto()).ToList();
        }
    }
}
