using ApiCadastroMusicos.Domain.Entites;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCadastroMusico.Entites
{
    public class Musico : Entidade
    {
        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public virtual ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();    

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime DataNascimento { get; set; }

        //public int Idade => DateTime.Now - DataNascimento
        
        public Guid EnderecoId { get; set; }

        public Endereco Endereco { get; private set; }

        public virtual ICollection<GrupoMusical> GruposMusicais { get; set; } = new List<GrupoMusical>();

        public Guid HabilidadeMusicalId { get; init; }
        public HabilidadeMusical HabilidadeMusical { get; init; }


        // Obrigar a iniciar a classe com esses parâmetros. 
        public Musico(string nome, string sobreNome, Endereco endereco)
        {
            Nome = nome;
            SobreNome = sobreNome;
            HabilidadeMusical ??= new(this);
            Endereco = endereco;
        }
        public Musico() { }

        public void AdicionarGrupoMusical(GrupoMusical grupoMusical)
        {
            var musicoJaEstaNoGrupoMusical = GruposMusicais.Any(x => x.Id == grupoMusical.Id);

            if (musicoJaEstaNoGrupoMusical) throw new ApplicationException("Músico já está no grupo musical");
            
            GruposMusicais.Add(grupoMusical);
        }

        public void AdicionarTelefone(Telefone telefone)
        {
            Telefones.Add(telefone);
        }
    }
}
