using FitnessPlanner.BLL.DTOs.WorkoutPlans;
using FitnessPlanner.BLL.Mappings;
using FitnessPlanner.DAL.Repositories;

namespace FitnessPlanner.BLL.Services
{
    public class WorkoutPlanService
    {
        private readonly WorkoutPlanRepository _workoutPlanRepository;
        private readonly UserRepository _userRepository;

        public WorkoutPlanService(
            WorkoutPlanRepository workoutPlanRepository,
            UserRepository userRepository)
        {
            _workoutPlanRepository = workoutPlanRepository;
            _userRepository = userRepository;
        }

        public async Task<List<WorkoutPlanReadDto>> GetAllAsync(int pageNumber,int pageSize)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 10;
            }

            var workoutPlans = await _workoutPlanRepository.GetAllAsync(pageNumber, pageSize);

            return workoutPlans.ToDtoList();
        }

        public async Task<WorkoutPlanReadDto> GetByIdAsync(int id)
        {
            var workoutPlan = await _workoutPlanRepository.GetByIdAsync(id);

            if (workoutPlan == null)
            {
                throw new KeyNotFoundException($"Workout plan with ID {id} was not found.");
            }

            return workoutPlan.ToDto();
        }

        public async Task<WorkoutPlanReadDto> CreateAsync(WorkoutPlanCreateDto dto)
        {
            var user = await _userRepository.GetByIdAsync(dto.UserId);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {dto.UserId} was not found.");
            }

            var workoutPlan = dto.ToEntity();

            await _workoutPlanRepository.AddAsync(workoutPlan);

            return workoutPlan.ToDto();
        }

        public async Task<WorkoutPlanReadDto> UpdateAsync(int id,WorkoutPlanUpdateDto dto)
        {
            var workoutPlan = await _workoutPlanRepository.GetByIdAsync(id);

            if (workoutPlan == null)
            {
                throw new KeyNotFoundException($"Workout plan with ID {id} was not found.");
            }

            workoutPlan.UpdateFromDto(dto);

            await _workoutPlanRepository.UpdateAsync();

            return workoutPlan.ToDto();
        }

        public async Task DeleteAsync(int id)
        {
            var workoutPlan = await _workoutPlanRepository.GetByIdAsync(id);

            if (workoutPlan == null)
            {
                throw new KeyNotFoundException($"Workout plan with ID {id} was not found.");
            }

            await _workoutPlanRepository.DeleteAsync(workoutPlan);
        }
    }
}
 