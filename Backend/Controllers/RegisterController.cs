using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Backend.Controllers
{
    public class RegisterController : ControllerBase
    {
        [HttpPost("register")]
        public void Post(NetUserRegister _request) {  

            DBResult res = Program.DB.IsUserTaken(_request.Username, _request.Email);

            if (!res.success) return;

            if ((bool)res.result == true) return;

            else Program.DB.CreateUser(_request.Username, _request.Email, _request.Password);
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
