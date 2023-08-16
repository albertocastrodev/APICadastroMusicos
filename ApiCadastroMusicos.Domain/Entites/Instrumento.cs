namespace ApiCadastroMusico.Entites
{
    public class Instrumento
    {
    
    public int Id { get; set; }

    public string Name { get; set; }

    public int TipoInstrumentoId { get; set; }

    public TipoInstrumento TipoInstrumento { get; set; }

    public int DadosMusicaisId { get; set; }

    public DadosMusicais DadosMusicais { get; set; }    
   
    
    }
}

