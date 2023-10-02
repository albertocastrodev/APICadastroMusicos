using ApiCadastroMusicos.Application.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCadastroMusicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> Post()
        {
            var jwtService = new JwtService();

            var token = jwtService.GenerateToken(new Domain.Entites.Usuario { });
            jwtService.ValidateToken(token);

            return Ok(token);
        }

        [HttpGet]
        public ActionResult<string> Validate(string token)
        {
            var jwtService = new JwtService();

            var result = jwtService.ValidateToken(token);

            return Ok(result);
        }
    }
}
