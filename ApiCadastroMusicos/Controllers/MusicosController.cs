using ApiCadastroMusico.Context;
using ApiCadastroMusico.DTO;
using ApiCadastroMusicos.Application.DTO.Request;
using ApiCadastroMusicos.Application.Interfaces;
using ApiCadastroMusicos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCadastroMusicos.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class MusicosController : ControllerBase
    {
        private readonly IMusicoAppService _musicoAppService;

        public MusicosController(IMusicoAppService pessoaAppService)
        {
            _musicoAppService = pessoaAppService;
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
            var pessoa = await _musicoAppService.GetById(id);
            return Ok(pessoa);
        }


        [HttpPost]
        public IActionResult Create([FromBody] MusicoCreateDto musicoDto)
        {
            _musicoAppService.Create(musicoDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] PessoaRequestDTO pessoaDTO)
        {
            _musicoAppService.Update(id, pessoaDTO);
            return Ok(pessoaDTO);
        }
    }

}