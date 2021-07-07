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
        public double ValorDestino { get; }

        public Leilao(string peca, double valorDestino = 0)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilaoEnum.LeilaoAntesDoPregao;
            ValorDestino = valorDestino;
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

            if (ValorDestino > 0)
            {
                Ganhador = Lances
                            .DefaultIfEmpty(new Lance(null, 0))
                            .Where(l => l.Valor > ValorDestino)
                            .OrderBy(lan => lan.Valor)
                            .FirstOrDefault();
            }
            else
            {
                Ganhador = Lances
                            .DefaultIfEmpty(new Lance(null, 0))
                            .OrderBy(lan => lan.Valor)
                            .LastOrDefault();
            }

            Estado = EstadoLeilaoEnum.LeilaoFinalizado;
        }

        private bool NovoLanceAceito(Interessada cliente, double valor)
        {
            return (Estado == EstadoLeilaoEnum.LeilaoEmAndamento && (_lances.Count == 0 || cliente != _lances.Last().Cliente));
        }
    }
}
