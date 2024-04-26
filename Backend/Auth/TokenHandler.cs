using Backend.Controllers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Backend.Auth;
using System.Security.Claims;



namespace Backend.Auth
{
    public class TokenHandler
    {
        
        public static bool ProtectedHandler(HttpResponse w, HttpRequest r, out string _username) {
            _username = "";

            if (!r.Headers.ContainsKey("Authorization")) {
                Responses.Unauthorized(w, "Missing authorization header");
                return false;
            }

            string _token = (string)r.Headers["Authorization"];
            _token = _token.Substring("Bearer ".Length);

            string _usernameClaim;
            if (!VerifyToken(_token, out _usernameClaim)) {
                Responses.Unauthorized(w, "Invalid token");
                return false;
            };

            _username = _usernameClaim;
            return true;
        }

        public static bool VerifyToken(string _srtToken, out string _username) {
            _username = "";

            var _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config.current.SecretKey));

            try {
                var _claims = new JwtSecurityTokenHandler().ValidateToken(
                    _srtToken,
                    new TokenValidationParameters {
                        IssuerSigningKey = _securityKey,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = Config.current.PageURL,
                        ValidAudience = Config.current.PageURL,
                    },
                    out var _token); ;

                string? _usernameClaim = _claims.FindFirstValue("username");
                if (_usernameClaim == null) throw new Exception("Claim is missing");

                _username = _usernameClaim;
                return true;
            }
            catch (Exception _e) {
                Console.WriteLine("VerifyToken: " + _e);
                return false;
            }
        }
    }
}
