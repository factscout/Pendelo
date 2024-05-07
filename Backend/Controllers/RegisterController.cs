using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] NetUserRegister _request) {  

            DBResult res = Program.DB.IsUserTaken(_request.Username, _request.Email);

            if (!res.success) return BadRequest("Usernname bereits vergeben");

            if ((bool)res.result == true) return BadRequest();

            else {
                Program.DB.CreateUser(_request.Username, _request.Email, _request.Password);
                return Ok("Benutzer Erstellt");
            }
        }
    }
    public class NetUserRegister
    {
        [Required] public string Email { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }

        public NetUserRegister(string email, string username, string password) {
            this.Email = email;
            this.Username = username;
            this.Password = password;
        }

        public NetUserRegister() { }

    }
}
