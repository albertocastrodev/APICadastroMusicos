using ApiCadastroMusico.Entites;
using Microsoft.EntityFrameworkCore;

namespace ApiCadastroMusico.Context
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Telefone> Telefones { get; set; }

        public DbSet<DadosMusicais> DadosMusicais { get; set; }


        public DbSet<Instrumento> Instrumentos { get; set; }
        
        public DbSet<TipoInstrumento> TipoDeInstrumentos { get; set; }

        public DbSet<GrupoMusical> GrupoMusicais { get; set; }

        
       



    }



}