using ApiCadastroMusico.Entites;
using Microsoft.EntityFrameworkCore;

namespace ApiCadastroMusico.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Musico> Musicos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<HabilidadeMusical> HabilidadesMusicais { get; set; }
        public DbSet<Instrumento> Instrumentos { get; set; }
        public DbSet<GrupoMusical> GruposMusicais { get; set; }
    }
}