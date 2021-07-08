using Alura.LeilaoOnline.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    internal class LeilaoEFConfig : IEntityTypeConfiguration<Leilao>
    {
        public void Configure(EntityTypeBuilder<Leilao> builder)
        {
            builder.HasOne<Lance>(l => l.Ganhador);
            builder.Property<EstadoLeilao>(l => l.Estado)
                .HasConversion(e => e.ToString(), e => Enum.Parse<EstadoLeilao>(e));
        }
    }
}