

using ApiCadastroMusico.DTO;
using ApiCadastroMusicos.DTO;

public class DadosMusicaisDTO
{


    public int Id { get; set; }

    public virtual ICollection<InstrumentoDTO> Instrumentos { get; set; }

    public virtual ICollection<GrupoMusicalDTO> GrupoMusicais { get; set; }

    public bool LeituraDeCifra { get; set; }
    public bool LeituraDePartitura { get; set; }

   




}


