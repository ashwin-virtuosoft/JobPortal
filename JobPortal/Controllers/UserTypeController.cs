using JobPortal.Model;
using JobPortal.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly UserTypeService _userTypeService;

        public UserTypeController(UserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }

        [HttpPost]
        [Route("userType")]
        public async Task<ActionResult> UserTypeInsert([FromBody] UserTypeMaster userTypeMaster)
        {
            try
            {
                bool result=await _userTypeService.UserTypeInsert(userTypeMaster);

                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());   
                return BadRequest();
            }
        }
    }
}
