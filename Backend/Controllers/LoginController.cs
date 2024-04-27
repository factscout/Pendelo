using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System.ComponentModel.DataAnnotations;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class UserLoginController : Controller
    {
        [HttpPost]
        public IActionResult CheckLogin([FromBody] NetUserLogin value) {

            DBResult result = Program.DB.CheckEmail(value.Email);

            if (!result.success) return BadRequest("Email wird nicht verwendet");


            bool? check = Program.DB.CheckLogin(value.Email, value.Password);

            if (check == null) {
           
                Console.WriteLine("LoginController: Password Check Failed");
                return BadRequest("Password Check Failed");
            }

            if (!(bool)check) {
                return BadRequest("Passwort ist falsch!");
            }

            string? _token = Auth.JSONWebToken.GenerateJSONWebToken(value.Email);
            var jsonresult = JsonConvert.SerializeObject(_token);

            if (jsonresult == null) {
                Responses.InternalServerError(Response);
                Console.WriteLine("LoginController: Token Generation Failed");
                return BadRequest("Token Generation Failed");
            }

            return Ok(new LoginResponse(jsonresult));

        }

        public class NetUserLogin
        {
            [Required] public string Email { get; set; }
            [Required] public string Password { get; set; }

            public NetUserLogin(string email, string password) {
                this.Email = email;
                this.Password = password;
            }

            public NetUserLogin() { }

        }
        public class LoginResponse
        {
            [Required] public string Token { get; set; }
            public LoginResponse(string token) {
                Token = token;
            }
        }
    }
}
