using Alura.LeilaoOnline.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core.Entidades
{
    public class Leilao
    {
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilaoEnum Estado { get; set; }

        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilaoEnum.LeilaoAntesDoPregao;
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if (NovoLanceAceito(cliente, valor))
                _lances.Add(new Lance(cliente, valor));
        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilaoEnum.LeilaoEmAndamento;
        }

        public void TerminaPregao()
        {
            if (Estado != EstadoLeilaoEnum.LeilaoEmAndamento) throw new InvalidOperationException("O Leilão não foi iniciado");

            Estado = EstadoLeilaoEnum.LeilaoFinalizado;
            Ganhador = Lances
                        .DefaultIfEmpty(new Lance(null, 0))
                        .OrderBy(lan => lan.Valor)
                        .LastOrDefault();
        }

        private bool NovoLanceAceito(Interessada cliente, double valor)
        {
            return (Estado == EstadoLeilaoEnum.LeilaoEmAndamento && (_lances.Count == 0 || cliente != _lances.Last().Cliente));
        }
    }
}
