using JWT_web_api.Data;
using JWT_web_api.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_web_api.Services
{
    public class UserService : IUserService
    {
        private IConfiguration _configuration;

        public UserService( IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Login(string email, string password)
        {
            //veritabanı kullanıcı doğrulama işlemi yapıldıktan sonra
            //token creation part
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecret"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expirationDate = DateTime.Now.AddDays(int.Parse(_configuration["JwtExperiryInDays"].ToString()));

            var claims = new[]
            {
                new Claim(ClaimTypes.Email,email)
            };

            var token = new JwtSecurityToken(_configuration["ValidIssuer"], _configuration["ValidAudience"],claims,null,expirationDate,creds);

            String tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
