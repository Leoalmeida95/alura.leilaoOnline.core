using Alura.LeilaoOnline.Core.Enums;
using Alura.LeilaoOnline.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core.Entidades
{
    public class Leilao
    {
        private IList<Lance> _lances;
        private IModalidadeAvaliacao _avaliador;

        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilaoEnum Estado { get; set; }

        public Leilao(string peca, IModalidadeAvaliacao avaliador)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Estado = EstadoLeilaoEnum.LeilaoAntesDoPregao;
            _avaliador = avaliador;
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

            Ganhador = _avaliador.Avalia(this);
            Estado = EstadoLeilaoEnum.LeilaoFinalizado;
        }

        private bool NovoLanceAceito(Interessada cliente, double valor)
        {
            return (Estado == EstadoLeilaoEnum.LeilaoEmAndamento && (_lances.Count == 0 || cliente != _lances.Last().Cliente));
        }
    }
}
