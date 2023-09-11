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

        public MusicosController(IMusicoAppService musicoAppService)
        {
            _musicoAppService = musicoAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var musicos = await _musicoAppService.Get();
            return Ok(musicos);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var musico = await _musicoAppService.GetById(id);

            if (musico is null) return NotFound();

            return Ok(musico);
        }

        [HttpGet("{musicoId:guid}/endereco")]
        public async Task<IActionResult> GetEnderecos(Guid musicoId)
        {
            var endereco = await _musicoAppService.GetEndereco(musicoId);

            if (endereco is null) return NotFound();

            return Ok(endereco);
        }



        [HttpGet("{musicoId:guid}/telefones")]
        public async Task<IActionResult> GetTelefones (Guid musicoId)
        {
            var telefones = await _musicoAppService.GetTelefones(musicoId);

            return Ok(telefones);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MusicoCreateDto musicoDto)
        {
            await _musicoAppService.Create(musicoDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] PessoaRequestDTO pessoaDTO)
        {
            //_musicoAppService.Update(id, pessoaDTO);
            //return Ok(pessoaDTO);
            throw new NotImplementedException();
        }
    }

}