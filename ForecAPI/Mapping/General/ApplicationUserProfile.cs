using ForecAPI.Application;
using ForecAPI.Dtos.General;
using ForecAPI.Models;

namespace ForecAPI.Mapping.General
{
    public class ApplicationUserProfile : MappingProfileBase
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUser, RegisterUserDto>()
              .ForMember(c => c.Role, c => c.Ignore())
              .ForMember(c => c.ConfirmPassword, c => c.Ignore()).ReverseMap();
        }
    }
}
