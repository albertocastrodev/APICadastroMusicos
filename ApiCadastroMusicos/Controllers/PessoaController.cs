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


        [HttpGet("GetById/Pessoa/{id:int}")]
        public IActionResult GetById(int id)
        {

            _pessoaAppService.GetById(id);
            return Ok();

        }


        [HttpPost]
        public IActionResult Post(PessoaRequestDTO pessoaDTO)
        {
            _pessoaAppService.Create(pessoaDTO);
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(PessoaDTO pessoaDTO)
        {

            _pessoaAppService.Update(pessoaDTO);
            return Ok(pessoaDTO);


        }
    }

}