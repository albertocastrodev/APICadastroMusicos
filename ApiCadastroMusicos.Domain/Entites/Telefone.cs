using ApiCadastroMusicos.Domain.Entites;

namespace ApiCadastroMusico.Entites;

public class Telefone : Entidade
{

    public string Numero { get; set; }

    public int DDD { get; set; }

    public Guid MusicoId { get; set; }

    public Musico Musico { get; set; }
}

