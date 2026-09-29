using FitnessPlanner.DAL.Repositories;
using FitnessPlanner.BLL.DTOs.MuscleGroups;
using FitnessPlanner.BLL.Mappings;


namespace FitnessPlanner.BLL.Services
{
    public class MuscleGroupService
    {
        private readonly MuscleGroupRepository _muscleGroupRepository;

        public MuscleGroupService(MuscleGroupRepository muscleGroupRepository)
        {
            _muscleGroupRepository = muscleGroupRepository;
        }

        public async Task<List<MuscleGroupReadDto>> GetAllAsync()
        {
            var muscleGroups =await _muscleGroupRepository.GetAllAsync();

            return muscleGroups.ToDtoList();
        }
    }
}