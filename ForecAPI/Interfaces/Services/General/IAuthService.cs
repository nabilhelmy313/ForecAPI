using ForecAPI.Application;
using ForecAPI.Dtos.General;

namespace ForecAPI.Interfaces.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> Login(LoginDto model);
        Task<ServiceResponse<int>> RegisterAccounUser(RegisterUserDto registerAccountUserDto);
    }
}
