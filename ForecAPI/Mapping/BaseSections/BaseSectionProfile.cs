using ForecAPI.Application;
using ForecAPI.Dtos.BaseSections;
using ForecAPI.Models;

namespace ForecAPI.Mapping.BaseSections
{
    public class BaseSectionProfile : MappingProfileBase
    {
        public BaseSectionProfile()
        {
            CreateMap<BaseSection, GetAllBaseSectionsDto>()
              .ForMember(c => c.BaseName, c => c.MapFrom(a=>a.Base.Name))
              .ReverseMap();

            CreateMap<BaseSection, AddBaseSectionDto>()
              .ReverseMap();
        }
    }
    }
