using ApiCadastroMusico.Entites;
using Microsoft.EntityFrameworkCore;

namespace ApiCadastroMusico.Context
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Musico> Pessoas { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Telefone> Telefones { get; set; }

        public DbSet<HabilidadeMusical> DadosMusicais { get; set; }


        public DbSet<Instrumento> Instrumentos { get; set; }
        
        public DbSet<TipoInstrumento> TipoDeInstrumentos { get; set; }

        public DbSet<GrupoMusical> GrupoMusicais { get; set; }

        
       



    }



}