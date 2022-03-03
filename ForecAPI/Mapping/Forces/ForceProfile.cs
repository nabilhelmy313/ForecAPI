using ForecAPI.Application;
using ForecAPI.Dtos.Forces;
using ForecAPI.Models;

namespace ForecAPI.Mapping.Forces
{
    public class ForceProfile : MappingProfileBase
    {
        public ForceProfile()
        {
            CreateMap<Force, GetAllForcesDto>()
             .ReverseMap();
            CreateMap<Force, AddForceDto>()
            .ReverseMap();
        }
    }
}
