using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    [Trait("Tipo", "Unidade")]
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo()
        {
            //Arranje
            var valorNegativo = -100;

            //Assert
            Assert.Throws<System.ArgumentException>(
                //Act
                () => new Lance(null, valorNegativo)
            );
        }

    }
}
