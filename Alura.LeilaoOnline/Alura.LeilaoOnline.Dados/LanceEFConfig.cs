using Alura.LeilaoOnline.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    internal class LanceEFConfig : IEntityTypeConfiguration<Lance>
    {
        public void Configure(EntityTypeBuilder<Lance> builder)
        {
            builder.HasOne<Leilao>(lance => lance.Leilao)
                .WithMany(leilao => leilao.Lances);
            builder.HasOne<Interessada>(lance => lance.Cliente)
                .WithMany(i => i.Lances);
        }
    }
}