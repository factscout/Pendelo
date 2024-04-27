using Backend.Auth;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Backend.Auth
{
    public class JSONWebToken
    {
        public static string? GenerateJSONWebToken(string email) {
            try {
                var _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config.current.SecretKey));
                var _credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);

                var _claims = new[] {
                    new Claim("email", email),
                };

                var token = new JwtSecurityToken(
                    Config.current.PageURL,
                    Config.current.PageURL,
                    _claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: _credentials);


                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception _e) {
                Console.WriteLine("GenerateJSONWebToken: " + _e.Message);
                return null;
            }
        }
    }
}
