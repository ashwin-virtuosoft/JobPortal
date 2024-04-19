using Google.Apis.Auth;
using JobPortal.Model;
using JobPortal.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {

        private readonly DemoService _demoService;
        private readonly JwtOptions _options;

        public DemoController(DemoService demoService)
        {
            _demoService = demoService;
        }

        [HttpPost]
        public async Task<ActionResult> PostDemoInsert([FromBody] Demo demo)
        {
            try
            {
                bool res=await _demoService.InsertDemo(demo);
                if (res)
                {
                    return Ok(res);

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return BadRequest($"Error Message:{ex.Message}");
            }
        }

        [HttpPost("google-Login")]
        public async Task<ActionResult> GoogleLogin([FromBody] LoginDto login)
        {
            var idToken = login.IdToken;
            var setting = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new string[]
                {
                    "1008159114589-ni8h18ikn5kp9l4j9gd03ia1f8tstq8i.apps.googleusercontent.com"
                }
            };
            GoogleJsonWebSignature.Payload result;
            try
            {
                result = await GoogleJsonWebSignature.ValidateAsync(idToken, setting);
            }
            catch (Exception ex)
            {
                // Handle validation error
                return BadRequest("Token validation failed: " + ex.Message);
            }

            if (result == null || string.IsNullOrEmpty(result.Email))
            {
                return BadRequest("Invalid token or email not found.");
            }

            var jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
            var credentials = new SigningCredentials(jwtKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>()
            {
                new Claim("Email", result.Email)
            };
            var sToken = new JwtSecurityToken(_options.Key, _options.Issuer, claims, expires: DateTime.Now.AddHours(5), signingCredentials: credentials);
            var token = new JwtSecurityTokenHandler().WriteToken(sToken);
            return Ok(new {token=token});
        }





    }
}
