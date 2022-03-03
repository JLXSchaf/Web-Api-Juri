using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/jurii")]
    public class JuriCompilerController : Controller
    {
        private static string Inhalt = new string("");
        
        [HttpGet]
        public async Task<JuriOutput> InterpretCode([FromQuery]string codeBase64)
        {
            
            var code = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(codeBase64));
            var interpreter = new Juri.Api.Interpreter();
            interpreter.ParseJuriProgram(code);
            
            if (!interpreter.ParsingOk())
            {
                return new JuriOutput()
                {
                    Standard = "",
                    Error = interpreter.GetOutputStreams().Error.ReadToEnd(),
                    Meta = ""
                };
            }
             
            interpreter.ExecuteProgram();
            var output = interpreter.GetOutputStreams();

            return new JuriOutput()
            {
                Standard = output.Standard.ReadToEnd(),
                Error = output.Error.ReadToEnd(),
                Meta = output.MetaInfo.ReadToEnd()
            };
        }
    }
}
