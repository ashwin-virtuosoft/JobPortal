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


        public HomeController( UserDetailsInsert userDetailsInsertService)
        {
            
            _userDetailsInsertService = userDetailsInsertService;

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
    }
}
