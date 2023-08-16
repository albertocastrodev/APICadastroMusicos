namespace ApiCadastroMusico.DTO
{
    public class InstrumentoDTO
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int TipoInstrumentoId { get; set; }

        public TipoInstrumentoDTO TipoInstrumento { get; set; }

        public int DadosMusicaisId { get; set; }

        public DadosMusicaisDTO DadosMusicais { get; set; }


    }
}

