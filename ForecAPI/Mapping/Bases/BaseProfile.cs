using ForecAPI.Application;
using ForecAPI.Dtos.Bases;
using ForecAPI.Models;

namespace ForecAPI.Mapping.Bases
{
    public class BaseProfile : MappingProfileBase
    {
        public BaseProfile()
        {
            CreateMap<Base, GetAllBasesDto>()
              .ForMember(c => c.ForceName, c => c.MapFrom(a=>a.Force.Name))
              .ReverseMap();
            CreateMap<Base, AddBaseDto>()
              .ReverseMap();
        }
    }
    }
