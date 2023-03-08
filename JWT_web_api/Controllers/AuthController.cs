using JWT_web_api.Infrastructure;
using JWT_web_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserService _service;

        public AuthController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("Login")]
        public String Login(String email, String password)
        {
            String res = _service.Login(email, password);
            return res;
        } 
    }
}
