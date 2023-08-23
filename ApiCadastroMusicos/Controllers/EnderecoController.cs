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

        //    [HttpPost]
        //    public IActionResult Post(EnderecoDTO enderecoDTO)

        //    {

        //        var endereco = new Endereco
        //        {
        //            Id = enderecoDTO.Id,
        //            Bairro = enderecoDTO.Bairro,
        //            Numero = enderecoDTO.Numero,
        //            Cep = enderecoDTO.Cep,
        //            UF = enderecoDTO.UF,
        //            Cidade = enderecoDTO.Cidade,
        //            Logradouro = enderecoDTO.Logradouro,

        //        };

        //        _context.Enderecos.Add(endereco);
        //        _context.SaveChanges();
        //        return Ok(endereco);
        //    }


        //    [HttpGet("GetById/Endereco/{id:int}")]
        //    public IActionResult GetById(int id)
        //    {
        //        var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);
        //        return Ok(endereco);
        //    }


        //}


    }
}