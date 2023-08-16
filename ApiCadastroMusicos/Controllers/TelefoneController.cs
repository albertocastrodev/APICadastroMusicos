using ApiCadastroMusico;
using ApiCadastroMusico.Context;
using ApiCadastroMusico.Entites;
using Microsoft.AspNetCore.Mvc;

namespace ApiCadastroMusicos.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class TelefoneController:ControllerBase
    {
       private readonly AppDbContext _context;

        public TelefoneController(AppDbContext context)

        {
            _context = context;

        }

        [HttpPost]
        public IActionResult Insert (TelefoneDTO TelefonesDTO)
        {

            var telefones = new Telefone
            {
                Id = TelefonesDTO.Id,
                DDD = TelefonesDTO.DDD,
                Numero = TelefonesDTO.Numero,


            };
            
            _context.Telefones.Add(telefones);
            _context.SaveChanges();
            return Ok(telefones);

        }

        [HttpGet]

        public IActionResult GetAll(TelefoneDTO telefoneDTO)
        {

            var telefones = new Telefone
            {
                Id = telefoneDTO.Id,
                DDD = telefoneDTO.DDD,
                Numero = telefoneDTO.Numero,

            };
            
            return Ok(telefones);
        
        }
        
        [HttpGet ("GetById/{id:int}")]

        public IActionResult GetById(int id) { 
        
        var telefone = _context.Telefones.FirstOrDefault (x => x.Id == id);

            var TelefonesDTO = new TelefoneDTO
            {

                Id= telefone.Id,
                DDD = telefone.DDD,
                Numero = telefone.Numero,  


            };



            return Ok(TelefonesDTO);
        
        }




    }


}
