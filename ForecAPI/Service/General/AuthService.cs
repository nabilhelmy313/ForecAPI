using AutoMapper;
using ForecAPI.Application;
using ForecAPI.Dtos.General;
using ForecAPI.Interfaces.Repositories.General;
using ForecAPI.Interfaces.Services;
using ForecAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace ForecAPI.Service.General
{
    public class AuthService:BaseService, IAuthService
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IMapper _Mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthService(IApplicationUserRepository applicationUserRepository, IMapper Mapper, UserManager<ApplicationUser> userManager)
        {
            _applicationUserRepository = applicationUserRepository;
            _Mapper = Mapper;
            _userManager = userManager;
        }
        public async Task<ServiceResponse<string>> Login(LoginDto model)
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
        public async Task<ServiceResponse<int>> RegisterAccounUser(RegisterUserDto registerAccountUserDto)
        {
            try
            {
                #region Guard
                var userExists = await _applicationUserRepository.GetUserByUserName(registerAccountUserDto.UserName);
                if (userExists != null ) return new ServiceResponse<int> { Success = false, Message = "اسم المستخدم موجود من قبل" };
                var idNumberExists = await _applicationUserRepository.GetUserByIdNumber(registerAccountUserDto.IDNumber);
                if (idNumberExists != null) return new ServiceResponse<int> { Success = false, Message = "رقم الهوية موجود من قبل" };
                var phoneExists = await _applicationUserRepository.GetUsersByPhoneNumber(registerAccountUserDto.PhoneNumber);
                if (phoneExists != null) return new ServiceResponse<int> { Success = false, Message = "رقم الهاتف موجود من قبل" };
                if (registerAccountUserDto.Password != registerAccountUserDto.ConfirmPassword) return new ServiceResponse<int> { Success = false, Message = "رقم السر وتاكيد رقم السر غير متطابقين" };
                #endregion
                var user = _Mapper.Map<ApplicationUser>(registerAccountUserDto);
                var result = await _userManager.CreateAsync(user, registerAccountUserDto.Password);
                if (!result.Succeeded) return new ServiceResponse<int> { Success = false, Message = string.Join(Environment.NewLine, result.Errors.Select(x => x.Description)) };
                await _applicationUserRepository.AddRoleToUser(user, registerAccountUserDto.Role);
                return new ServiceResponse<int> { Success = true, Data = 1 };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
