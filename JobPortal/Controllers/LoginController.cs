using JobPortal.Model;
using JobPortal.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        public async Task<ActionResult> LoginUser([FromBody] Login login)
        {
            bool result = await _loginService.UserLogin(login);

            if (result) 
            {
                return Ok("Login Success");
            }
            else
            {
                return Unauthorized("Failed");
            }
        }
    }
}
