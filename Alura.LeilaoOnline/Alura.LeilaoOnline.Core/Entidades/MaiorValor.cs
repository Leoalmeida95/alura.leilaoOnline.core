using Alura.LeilaoOnline.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Core.Entidades
{
    public class MaiorValor : Interfaces.IModalidadeAvaliacao
    {
        public Lance Avalia(Leilao leilao)
        {
            return leilao
                    .Lances
                    .DefaultIfEmpty(new Lance(null, 0))
                    .OrderBy(lan => lan.Valor)
                    .LastOrDefault();
        }
    }
}
