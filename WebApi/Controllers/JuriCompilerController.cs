using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/juric")]
    [ApiController]
    public class JuriCompilerController : Controller
    {
        private static string Inhalt = new string("");
        
        [HttpGet("{Inhalt}")]
        public async Task<ActionResult<JuriCompiler>> Get(string Inhalt)
        {
            var ínterpreter = new API.Interpreter();
            ínterpreter.ParseJuriProgram(Inhalt);
            ínterpreter.ExecuteProgram();
            return Ok("{result: SMOLPP}");

            // .net popo
        }
    }
}
