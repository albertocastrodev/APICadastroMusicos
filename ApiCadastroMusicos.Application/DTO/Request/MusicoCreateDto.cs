using ApiCadastroMusico;
using ApiCadastroMusico.Entites;
using System.ComponentModel.DataAnnotations;

namespace ApiCadastroMusicos.Application.DTO.Request
{
    public class MusicoCreateDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string SobreNome { get; set; }

        [Required]
        public virtual ICollection<TelefoneDTO> Telefones { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        public List<Guid> Instrumentos { get; set; } = new List<Guid>();
        public bool LeituraDeCifra { get; set; }
        public bool LeituraDePartitura { get; set; }

        public List<Guid> GruposMusicais { get; set; } = new List<Guid>();

        [Required]
        public EnderecoCreateDto Endereco { get; set; } = new();

        public class EnderecoCreateDto
        {
            [Required]
            public string Logradouro { get; set; }

            [Required]
            public string Numero { get; set; }

            [Required]
            public string Bairro { get; set; }

            [Required]
            public string Cidade { get; set; }

            [Required]
            public string Cep { get; set; }

            [Required]
            public string UF { get; set; }
        }
    }
}
