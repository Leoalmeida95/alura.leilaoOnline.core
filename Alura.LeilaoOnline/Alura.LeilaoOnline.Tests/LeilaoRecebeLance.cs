using Alura.LeilaoOnline.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeLance
    {
        [Fact]
        public void NaoPermiteNovosLancesQuandoLeilaoFinalizado()
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var ciclano = new Interessada("Ciclano", leilao);
            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 700);
            leilao.RecebeLance(ciclano, 800);
            leilao.TerminaPregao();

            //Act - método sendo testado
            leilao.RecebeLance(fulano, 1000);

            //Assert
            var valorEsperado = 2;
            Assert.Equal(valorEsperado, leilao.Lances.Count());
        }

        [Fact]
        public void NaoAceitaLancesConsecutivosDoMesmoInteressado()
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.IniciaPregao();

            leilao.RecebeLance(fulano, 700);

            //Act - método sendo testado
            leilao.RecebeLance(fulano, 1000);

            leilao.TerminaPregao();
            //Assert
            var qtdEsperada = 1;
            Assert.Equal(qtdEsperada, leilao.Lances.Count());
        }
    }
}
