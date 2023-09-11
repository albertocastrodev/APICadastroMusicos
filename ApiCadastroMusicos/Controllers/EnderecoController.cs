using ApiCadastroMusico.Context;
using ApiCadastroMusico.Entites;
using ApiCadastroMusicos.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiCadastroMusicos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnderecoController(AppDbContext context)

        {
            _context = context;

        }
    }
}