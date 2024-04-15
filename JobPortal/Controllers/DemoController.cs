using JobPortal.Model;
using JobPortal.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {

        private readonly DemoService _demoService;

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

        
    }
}
