using ApiCadastroMusico.Entites;
using ApiCadastroMusicos.DTO;
using System.Text.Json.Serialization;

namespace ApiCadastroMusico.DTO
{
    public class MusicoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public virtual ICollection<Telefone> Telefones { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime DataNascimento { get; set; }

        //public int Idade => DateTime.Now - DataNascimento

        public Guid EnderecoId { get; set; }

        public Endereco Endereco { get; set; }

        public virtual ICollection<GrupoMusical> GruposMusicais { get; set; }

        public int DadosMusicaisId { get; set; }
        public HabilidadeMusicalDto HabilidadeMusical { get; init; }

        public class HabilidadeMusicalDto
        {
            public virtual ICollection<Instrumento> Instrumentos { get; set; } = new List<Instrumento>();
            public bool LeituraDeCifra { get; set; }
            public bool LeituraDePartitura { get; set; }
        }
    }
}
