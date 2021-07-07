using Alura.LeilaoOnline.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Core.Entidades
{
    public class OfertaSuperiorMaisProxima : Interfaces.IModalidadeAvaliacao
    {
        public double ValorDestino { get; }

        public OfertaSuperiorMaisProxima(double valorDestino)
        {
            ValorDestino = valorDestino;
        }

        public Lance Avalia(Leilao leilao)
        {
            return leilao
                        .Lances
                        .DefaultIfEmpty(new Lance(null, 0))
                        .Where(l => l.Valor > ValorDestino)
                        .OrderBy(lan => lan.Valor)
                        .FirstOrDefault();
        }
    }
}
