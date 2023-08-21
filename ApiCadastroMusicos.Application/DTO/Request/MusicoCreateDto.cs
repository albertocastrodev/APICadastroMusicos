using ApiCadastroMusico.Entites;
using ApiCadastroMusicos.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCadastroMusicos.Application.DTO.Request
{
    public class MusicoCreateDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string SobreNome { get; set; }

        [Required]
        public virtual ICollection<Telefone> Telefones { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public EnderecoDTO Endereco { get; set; }

     //   public virtual ICollection<GrupoMusical> GruposMusicais { get; set; }

        public class EnderecoDTO
        {

        }
    
    }
}
