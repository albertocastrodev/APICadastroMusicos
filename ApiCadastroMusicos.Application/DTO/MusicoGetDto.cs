using ApiCadastroMusico.Entites;
using ApiCadastroMusicos.DTO;
using System.Text.Json.Serialization;

namespace ApiCadastroMusico.DTO
{
    public class MusicoGetDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime DataNascimento { get; set; }  
    }
}
