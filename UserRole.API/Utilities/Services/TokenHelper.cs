using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserRole.API.Utilities.Models;
using UserRole.Framework.Utilities;

namespace UserRole.API.Utilities.Services
{
    public class TokenHelper
    {
        private readonly IConfiguration _configuration;
        public TokenHelper(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public TokenModel GenerateToken(int UserId, string Username, string RoleName)
        {
            if (!Username.IsNotNull())
            {
                Username = "Anonymous";
            }
            var now = DateTime.UtcNow;
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.UTF8.GetBytes(this._configuration["JwtKey"]);
            var expDate = now.AddHours(3);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new(ClaimTypes.Name, Username), new(ClaimTypes.NameIdentifier, $"{UserId}"), new(ClaimTypes.Role, RoleName.IsNotNull() ? RoleName : string.Empty) }),
                Expires = expDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new TokenModel
            {
                ExpirationTime = expDate,
                Name = Username,
                Token = tokenHandler.WriteToken(token),
            };
        }
    }
}
