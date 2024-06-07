using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Transactions;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RidesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] Ride _request) {
            if (Auth.TokenHandler.ProtectedHandler(Response, Request, out string _username)) {

                int? _id  = Program.DB.GetUserIDFromUsername(_username); 
                if (_id == null) {
                    Responses.InternalServerError(Response);
                    Console.WriteLine("UserController: Failed to fetch UserID");
                    return BadRequest("No User found");
                }

                Program.DB.CreateTransaction((int)_id, _request);
                return Ok(new { Message = "Ride erfolgreich eingetragen" });
            }
            return Unauthorized();
        }
    }
}
