using ApiCadastroMusico.Context;
using ApiCadastroMusico.DTO;
using ApiCadastroMusicos.Application.Interfaces;
using ApiCadastroMusicos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCadastroMusicos.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaAppService _pessoaAppService;

        public PessoaController(IPessoaAppService pessoaAppService)
        {
            _pessoaAppService = pessoaAppService;
        }

        //[HttpGet]
        //public ActionResult GetAll()
        //{
        //    var pessoaDTO = _context.Pessoas.Include(c => c.Telefones).Include(c => c.Endereco).Select(pessoa => new PessoaDTO
        //    {

        //        Nome = pessoa.Nome,
        //        SobreNome = pessoa.SobreNome,
        //        Idade = pessoa.Idade,
        //        DataCadastro = pessoa.DataCadastro,
        //    });

        //    if (pessoaDTO != null)
        //    {

        //        return NotFound("Nenhuma pessoa cadastrada");
        //    }
        //    return Ok(pessoaDTO);

        //}


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pessoa = await _pessoaAppService.GetById(id);
            return Ok(pessoa);
        }


        [HttpPost]
        public IActionResult Post([FromBody] PessoaRequestDTO pessoaDTO)
        {
            _pessoaAppService.Create(pessoaDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] PessoaRequestDTO pessoaDTO)
        {
            _pessoaAppService.Update(id, pessoaDTO);
            return Ok(pessoaDTO);
        }
    }

}