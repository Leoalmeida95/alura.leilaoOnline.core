﻿using Alura.LeilaoOnline.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorQuandoLeilaoComPeloMenosUmLance(double valorEsperado, double[] ofertas)
        {
            //Arranje - cenário
            //Dado leilão com 3 clientes e lances realizados por eles
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var leo = new Interessada("Leo", leilao);

            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                if (i % 2 == 0)
                    leilao.RecebeLance(fulano, ofertas[i]);
                else
                    leilao.RecebeLance(leo, ofertas[i]);
            }

            //Act - método sendo testado
            //Quando o pregão/leilão termina
            leilao.TerminaPregao();

            //Assert
            //Então o valor esperado é o maior valor lançado
            //e o cliente ganhador é o que deu maior lance
            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);
        }

        [Fact]
        public void RetornaZeroQuandoLeilaoSemLances()
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            leilao.IniciaPregao();

            //Act - método sendo testado
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 0;
            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);
        }

        [Fact]
        public void LancaInvalidOperationExceptionQuandoPregaoNaoIniciado()
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");

            //Assert
            var excecaoObtida = Assert.Throws<InvalidOperationException>(
                //Act - método sendo testado
                () => leilao.TerminaPregao()
                );

            var messageEsperada = "O Leilão não foi iniciado";
            Assert.Equal(messageEsperada, excecaoObtida.Message);
        }
    }
}
