using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;
using System.ComponentModel.DataAnnotations;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class UserLoginController : Controller
    {
        [HttpPost("login")]
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

            DBResult getid = Program.DB.GetID(value.Email);
            return Ok(getid.result);

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
    }
}
