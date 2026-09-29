using FitnessPlanner.DTOs.MuscleGroups;
using FitnessPlanner.Models;

namespace FitnessPlanner.API.Mappings
{
    public static class MuscleGroupMappings
    {
        public static MuscleGroupReadDto ToDto(this MuscleGroup muscleGroup)
        {
            return new MuscleGroupReadDto
            {
                MuscleGroupId = muscleGroup.MuscleGroupId,
                Name = muscleGroup.Name
            };
        }

        public static List<MuscleGroupReadDto> ToDtoList(this IEnumerable<MuscleGroup> muscleGroups)
        {
            return muscleGroups
                .Select(mg => mg.ToDto())
                .ToList();
        }
    }
}