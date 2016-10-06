using _01_DAL.Dto;
using _02_WebService.Code;
using System.Web.Http;

namespace _02_WebService.Controllers
{
    [AllowAnonymous]
    public class AuthController : ApiController
    {               
        [Route("api/auth/token")]
        [HttpPost]
        public IHttpActionResult Get(LoginRequest loginRequest)
        {
            //remove this
            if(loginRequest == null)
            {
                loginRequest = new LoginRequest()
                {
                    Username = "marcos",
                    Password = "gil"
                };
            }
            
            var token = AppUser.Authenticate(loginRequest);
            return Ok(token);
        }
    }
}