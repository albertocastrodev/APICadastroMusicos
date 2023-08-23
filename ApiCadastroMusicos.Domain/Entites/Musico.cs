using ApiCadastroMusicos.Domain.Entites;

namespace ApiCadastroMusico.Entites
{
    public class Musico : Entidade
    {
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
        public HabilidadeMusical HabilidadeMusical { get; init; }

        // Obrigar a iniciar a classe com esses parâmetros. 
        public Musico(string nome, string sobreNome)
        {
            Nome = nome;
            SobreNome = sobreNome;
            HabilidadeMusical ??= new(this);
        }
    }
}
