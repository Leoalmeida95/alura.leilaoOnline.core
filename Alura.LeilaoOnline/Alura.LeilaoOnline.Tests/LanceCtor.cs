using Alura.LeilaoOnline.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionQuandoValorNegativo()
        {
            //Arranje
            var valorNegativo = -100;

            //Assert
            Assert.Throws<ArgumentException>(
                //Act - método sendo testado
                () => new Lance(null, valorNegativo)
                );
        }
    }
}
