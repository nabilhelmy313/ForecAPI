using ForecAPI.Interfaces.Repositories.General;
using ForecAPI.Models;
using ForecAPI.Models.General;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ForecAPI.Repoitories.General
{
    public class ApplicationUserRepository: IApplicationUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ForceDbContext _forceDbContext;

        public ApplicationUserRepository(UserManager<ApplicationUser> userManager, ForceDbContext forceDbContext)
        {
            _userManager = userManager;
            _forceDbContext = forceDbContext;
        }
        public async Task<Token> GetToken(string userName, string password, string topSecretKey, string issuer, string audience)
        {
            try
            {

                var user = await _userManager.Users.Where(q => q.UserName == userName).FirstOrDefaultAsync();
                if (user != null )
                {
                    if(!await _userManager.CheckPasswordAsync(user, password))
                        return new Token
                        {
                            Tokenstring = null,
                            ErrorMessage = "كلمة السر غير صحيحة"
                        };
                    var claims = new[]{
                    new Claim(JwtRegisteredClaimNames.UniqueName, userName),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString())
                };

                    var superSecretPassword = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(topSecretKey));

                    var token = new JwtSecurityToken(
                        issuer: issuer,
                        audience: audience,
                        expires: DateTime.Now.AddDays(1),
                        claims: claims,
                        signingCredentials: new SigningCredentials(superSecretPassword, SecurityAlgorithms.HmacSha256)
                    );

                    return new Token
                    {
                        Tokenstring = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo,
                        CurrentUser = user
                      

                    };
                }
               
                return new Token
                {
                    Tokenstring=null,
                    ErrorMessage = "اسم المستخدم غير صحيح"


                }; 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
