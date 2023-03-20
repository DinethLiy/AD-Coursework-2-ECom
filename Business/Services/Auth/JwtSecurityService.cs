using eComMaster.Business.Interfaces.Auth;
using eComMaster.Models.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eComMaster.Business.Services.Auth
{
    public class JwtSecurityService : IJwtSecurityService
    {
        private readonly string key;
        public JwtSecurityService(string key)
        {
            this.key = key;
        }

        // Creates and return a JSON Web Token (JWT),
        // The JWT stores the logged in user's "PRIVILEGE_TYPE" attribute for authorization purposes and the the user's ID (to be used to track data creation/modification etc.)
        public string JwtAuthentication(AuthUser user)
        {
            // Set Claims for Token
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Role, user.PRIVILEGE_TYPE),
                new Claim("UserId", user.USER_ID.ToString())
            };

            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(key);

            // 3. Create Token
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature));

            // 4. Return Token from method
            return tokenHandler.WriteToken(token);
        }
    }
}
