using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/")]
    
    public class main : Controller
    {

        [HttpGet("")]
        public async Task<ActionResult<JuriCompiler>> Get()
        {
            return Ok("asdasd");

        }
    }
}
