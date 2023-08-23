using ApiCadastroMusico.Entites;
using Microsoft.EntityFrameworkCore;

namespace ApiCadastroMusico.Context
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Musico> Musico { get; set; }

        public DbSet<Endereco> Endereco { get; set; }

        public DbSet<Telefone> Telefone { get; set; }

        public DbSet<HabilidadeMusical> HabilidadeMusical { get; set; }


        public DbSet<Instrumento> Instrumento { get; set; }
        

        
      


    }



}