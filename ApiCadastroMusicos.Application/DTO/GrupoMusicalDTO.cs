namespace ApiCadastroMusico.DTO;

public class GrupoMusicalDTO
{

    public int Id { get; set; }
    public string Name { get; set; }

    public int QuantidadeIntegrantes { get; set; }

    public int DadosMusicaisId { get; set; }

    public DadosMusicaisDTO DadosMusicais { get; set; } 

}
