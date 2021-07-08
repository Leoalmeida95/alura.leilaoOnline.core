using Microsoft.EntityFrameworkCore;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public class LeiloesContext : DbContext
    {
        public DbSet<Leilao> Leiloes { get; set; }
        public DbSet<Interessada> Interessada { get; set; }
        public DbSet<Lance> Lance { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }

        public LeiloesContext(DbContextOptions<LeiloesContext> dbContextOptions) : 
            base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Leilao>(new LeilaoEFConfig());
            modelBuilder.ApplyConfiguration<Lance>(new LanceEFConfig());
            modelBuilder.ApplyConfiguration<Interessada>(new InteressadaEFConfig());
            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioEFConfig());
            modelBuilder.ApplyConfiguration<Favorito>(new FavoritoEFConfig());

        }
    }
}
