using ApiCadastroMusicos.Domain.Entites;
using System.Runtime.Serialization;

namespace ApiCadastroMusico.Entites
{
    public class Instrumento: Entidade
    {
        public string Name { get; set; }

        public TipoInstrumento TipoInstrumento { get; set; }

        public ICollection<HabilidadeMusical> HabilidadesMusicais { get; init; }

        public IEnumerable<Musico> Musicos => HabilidadesMusicais.Select(x => x.Musico);
    }
}

