using System.Collections.Generic;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace Alura.LeilaoOnline.Core
{
    public static class EstadoLeilaoExtensions
    {
        public static string ParaTexto(this EstadoLeilao estado)
        {
            switch (estado)
            {
                case EstadoLeilao.LeilaoAntesDoPregao:
                    return "Pregão não iniciado";
                case EstadoLeilao.LeilaoEmAndamento:
                    return "Pregão em andamento";
                case EstadoLeilao.LeilaoFinalizado:
                    return "Pregão encerrado";
                default:
                    return "Estado não encontrado";
            }
        }
    }

    public enum EstadoLeilao
    {
        LeilaoAntesDoPregao,
        LeilaoEmAndamento,
        LeilaoFinalizado
    }

    public class Leilao
    {
        private Interessada _ultimoCliente;
        private IModalidadeAvaliacao _avaliador;

        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required]
        public string Imagem { get; set; }
        public double ValorInicial { get; set; }
        public DateTime InicioPregao { get; set; }
        public DateTime TerminoPregao { get; set; }
        public EstadoLeilao Estado { get; private set; }
        public IList<Lance> Lances { get; private set; }
        public IList<Favorito> Seguidores { get; private set; }
        public Lance Ganhador { get; private set; }

        //para uso do EF Core
        private Leilao()
        {

        }

        public Leilao(string titulo, IModalidadeAvaliacao avaliador)
        {
            Titulo = titulo;
            Lances = new List<Lance>();
            Estado = EstadoLeilao.LeilaoAntesDoPregao;
            _avaliador = avaliador;
        }

        private bool NovoLanceEhAceito(Interessada cliente, double valor)
        {
            return (Estado == EstadoLeilao.LeilaoEmAndamento)
                && (cliente != _ultimoCliente);
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if (NovoLanceEhAceito(cliente, valor))
            {
                Lances.Add(new Lance(cliente, valor));
                _ultimoCliente = cliente;
            }
        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilao.LeilaoEmAndamento;
        }

        public void TerminaPregao()
        {
            if (Estado != EstadoLeilao.LeilaoEmAndamento)
            {
                throw new System.InvalidOperationException("Não é possível terminar o pregão sem que ele tenha começado. Para isso, utilize o método IniciaPregao().");
            }
            Ganhador = _avaliador.Avalia(this);
            Estado = EstadoLeilao.LeilaoFinalizado;
        }

        public double ValorDoLanceAtual => Lances.Select(l => l.Valor).LastOrDefault();
    }
}
