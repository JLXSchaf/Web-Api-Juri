using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/jurii")]
    public class JuriCompilerController : Controller
    {
        private static string Inhalt = new string("");
        
        [HttpGet]
        public async Task<JuriOutput> InterpretCode([FromQuery]string codeBase64Url)
        {
            
            var codedecoded = Microsoft.AspNetCore.WebUtilities.WebEncoders.Base64UrlDecode(codeBase64Url);
            // byte[] to string
            var codestring = System.Text.Encoding.UTF8.GetString(codedecoded);

            var interpreter = new Juri.Api.Interpreter();
            interpreter.ParseJuriProgram(codestring);
            
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
