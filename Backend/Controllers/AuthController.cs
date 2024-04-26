using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using Backend.Auth;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        // TODO: Create new token when old one is outdated.
        // This is really really bad and stupid

        [HttpGet]
        public void Get() {
            if (TokenHandler.ProtectedHandler(Response, Request, out string _username)) {
                string _token = (string)Request.Headers["Authorization"];
                _token = _token.Substring("Bearer ".Length);

                Responses.JsonOk(Response, new UserLoginController.LoginResponse(_token));
            }
        }


    }
}
