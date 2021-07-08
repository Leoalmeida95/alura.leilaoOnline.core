using Alura.LeilaoOnline.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    internal class UsuarioEFConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasData(new { Id = 1, Email = "fulano@example.org", Senha = "123", InteressadaId = 1 });
            builder.HasData(new { Id = 2, Email = "mariana@example.org", Senha = "456", InteressadaId = 2 });
            builder.HasData(new { Id = 3, Email = "admin@example.org", Senha = "123" });
        }
    }
}