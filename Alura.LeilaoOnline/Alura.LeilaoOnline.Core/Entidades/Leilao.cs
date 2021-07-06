using Alura.LeilaoOnline.Core.Enums;
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
            if (Estado == EstadoLeilaoEnum.LeilaoEmAndamento) _lances.Add(new Lance(cliente, valor));
        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilaoEnum.LeilaoEmAndamento;
        }

        public void TerminaPregao()
        {
            Estado = EstadoLeilaoEnum.LeilaoFinalizado;
            Ganhador = Lances
                        .DefaultIfEmpty(new Lance(null, 0))
                        .OrderBy(lan => lan.Valor)
                        .LastOrDefault();
        }
    }
}
