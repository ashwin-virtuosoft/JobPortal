using JobPortal.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobPortal.services;
namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

  
        private readonly UserDetailsInsert _userDetailsInsertService;
        private readonly GetUserDetails _getUserDetailsService;


        public HomeController( UserDetailsInsert userDetailsInsertService,GetUserDetails getUserDetailsService)
        {
            
            _userDetailsInsertService = userDetailsInsertService;
            _getUserDetailsService = getUserDetailsService;

        }
        [HttpPost("user")]
        public async Task<IActionResult> PostUserDetails([FromBody] UserDetails userDetails)
        {
            try
            {
                bool result = await _userDetailsInsertService.InsertUser(userDetails);

                if (result)
                {
                    return Ok(result);

                }
                else
                {
                    return BadRequest();
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex);

                return BadRequest($"Error Message:{ ex.Message}");
            }
        }

        [HttpGet("AdminGet")]
        public async Task<IActionResult> GetUserDetails()
        {
            List<UserDetails> userResult = await _getUserDetailsService.GetUser();

            if (userResult != null && userResult.Count > 0)
            {
                return Ok(userResult);
            }
            else
            {
                return BadRequest("No user details found.");
            }
        }

    }
}
