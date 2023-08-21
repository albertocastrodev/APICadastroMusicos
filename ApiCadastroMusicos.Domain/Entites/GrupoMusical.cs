using ApiCadastroMusicos.Domain.Entites;

namespace ApiCadastroMusico.Entites
{
    public class GrupoMusical : Entidade
    {
        public string Name { get; set; }

        public int QuantidadeIntegrantes => Musicos?.Count ?? 0;

        public ICollection<Musico> Musicos { get; init; }

    }
}
