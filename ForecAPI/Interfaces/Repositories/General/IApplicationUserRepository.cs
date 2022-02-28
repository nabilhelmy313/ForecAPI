using ForecAPI.Models.General;

namespace ForecAPI.Interfaces.Repositories.General
{
    public interface IApplicationUserRepository
    {
        Task<Token> GetToken(string userName, string password, string topSecretKey, string issuer, string audience);

    }
}
