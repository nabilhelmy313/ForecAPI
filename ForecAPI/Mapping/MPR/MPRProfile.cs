using ForecAPI.Application;
using ForecAPI.Dtos.MPR;

namespace ForecAPI.Mapping.MPR
{
    public class MPRProfile : MappingProfileBase
    {
        public MPRProfile()
        {
            CreateMap<ForecAPI.Models.MPR, AddMPRDto>()
            .ForMember(c => c.File, c => c.Ignore())
            .ForMember(c => c.ContentType, c => c.Ignore())
            .ForMember(c => c.FileName, c => c.Ignore())
            
            .ReverseMap();

            CreateMap<ForecAPI.Models.MPR, GetMPRsDto>()
           .ForMember(c => c.Date, c => c.MapFrom(a=>a.Date.Date.ToString("yyyy-MM-dd")))
           .ForMember(c => c.Status, c => c.MapFrom(a=>a.MPRStatus.Name))
           .ReverseMap();

            CreateMap<ForecAPI.Models.MPR, GetMPRDetailDto>()
                  .ForMember(c => c.Filepath, c => c.Ignore())
        .ForMember(c => c.Date, c => c.MapFrom(a => a.Date.Date.ToString("yyyy-MM-dd")))
        .ForMember(c => c.Status, c => c.MapFrom(a => a.MPRStatus.Name))
          .ForMember(c => c.Type, c => c.MapFrom(a => a.MPRType.Name))
            .ForMember(c => c.MethodofDelivery, c => c.MapFrom(a => a.MPRMethodofDelivery.Name))
              .ForMember(c => c.AddressForDelivery, c => c.MapFrom(a => a.AddressOfDelivery.Name))
        .ReverseMap();
        }
    }
}
