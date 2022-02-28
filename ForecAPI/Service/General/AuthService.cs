using ForecAPI.Application;
using ForecAPI.Dtos.General;
using ForecAPI.Interfaces.Repositories.General;
using ForecAPI.Interfaces.Services;

namespace ForecAPI.Service.General
{
    public class AuthService:BaseService, IAuthService
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        public AuthService(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }
        public async Task<ServiceResponse<string>> Login(LoginModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.UserName) || string.IsNullOrWhiteSpace(model.Password))
                    return new ServiceResponse<string> { Success = false, Data = null, Message ="معلومات ناقصة" };

                var token = await _applicationUserRepository.GetToken(model.UserName, model.Password, "ForceSuperSecretPassword", "Force.com", "Force.com");
                if (token.Tokenstring == null) return new ServiceResponse<string> { Success = false, Data = null, Message = token.ErrorMessage};
                return new ServiceResponse<string> { Success = true, Data = token.Tokenstring };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
