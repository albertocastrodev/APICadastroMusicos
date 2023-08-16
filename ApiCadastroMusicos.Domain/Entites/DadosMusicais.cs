namespace ApiCadastroMusico.Entites
{
    public class DadosMusicais
    {
        public int Id { get; set; }

        public virtual ICollection<Instrumento> Instrumentos { get; set; }

        public virtual ICollection<GrupoMusical> GrupoMusicais { get; set; }

        public bool LeituraDeCifra { get; set; }
        public bool LeituraDePartitura { get; set; }

    }
}
