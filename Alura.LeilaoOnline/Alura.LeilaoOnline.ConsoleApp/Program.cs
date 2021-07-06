using Alura.LeilaoOnline.Core;
using System;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        private static void LeilaoComVariosLances()
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(maria, 700);
            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 1000);
            leilao.RecebeLance(fulano, 900);

            //Act - método sendo testado
            leilao.TerminaPregao();

            var valorObtido = leilao.Ganhador.Valor;
            var valorEsperado = 1000;

            //Assert
            if (valorObtido == valorEsperado)
            {
                Console.WriteLine("TESTE PASSOU");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("TESTE FALHOU");
                Console.ReadLine();
            }
        }

        static void Main()
        {
            LeilaoComVariosLances();
        }
    }
}
