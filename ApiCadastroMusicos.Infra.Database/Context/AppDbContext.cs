using ApiCadastroMusico.Entites;
using Microsoft.EntityFrameworkCore;

namespace ApiCadastroMusico.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instrumento>().Ignore(x => x.Musicos);

            modelBuilder.Entity<Musico>().Property(x => x.Nome).HasMaxLength(100);
            modelBuilder.Entity<Musico>().Property(x => x.Nome).IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Musico> Musicos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<HabilidadeMusical> HabilidadesMusicais { get; set; }
        public DbSet<Instrumento> Instrumentos { get; set; }
        public DbSet<GrupoMusical> GruposMusicais { get; set; }
    }
}