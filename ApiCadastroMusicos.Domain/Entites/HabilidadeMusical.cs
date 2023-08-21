using ApiCadastroMusicos.Domain.Entites;

namespace ApiCadastroMusico.Entites
{
    public class HabilidadeMusical : Entidade
    {
        public virtual ICollection<Instrumento> Instrumentos { get; set; } = new List<Instrumento>();

        public Musico Musico { get; init; }
        public bool LeituraDeCifra { get; set; }
        public bool LeituraDePartitura { get; set; }

        public HabilidadeMusical(Musico musico)
        {
            Musico = musico;
        }

        public void AdicionarHabilidadeInstrumental(Instrumento instrumento)
        {
            if (Instrumentos.Any(x => x.Id == instrumento.Id)) throw new ApplicationException("Instrumento já cadastrado para o músico");

            Instrumentos.Add(instrumento);
        }

    }
}
