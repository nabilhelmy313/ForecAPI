using ForecAPI.Models;
using ForecAPI.Models.General;

namespace ForecAPI.Interfaces.Repositories.General
{
    public interface IApplicationUserRepository
    {
        Task<Token> GetToken(string userName, string password, string topSecretKey, string issuer, string audience);
        Task<ApplicationUser> GetUserByUserName(string userName);
        Task<ApplicationUser> GetUserByIdNumber(string IdNumber);
        Task<ApplicationUser> GetUsersByPhoneNumber(string PhoneNumber);
        Task AddRoleToUser(ApplicationUser user, string Role);
    }
}
