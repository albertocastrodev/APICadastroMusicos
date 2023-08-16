namespace ApiCadastroMusico.Entites
{
    public class GrupoMusical
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public int QuantidadeIntegrantes { get; set; }

        public int DadosMusicaisId { get; set; }

        public DadosMusicais DadosMusicais { get; set; } 

    }
}
