using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Tests
{
    [Collection("Chrome Drive")]
    public class AoOfertarLance
    {
        private IWebDriver _driver;
        private LoginPO loginPO;
        private DetalheLeilaoPO detalheLeilaoPO;

        public AoOfertarLance(TestFixture _fixture)
        {
            _driver = _fixture.driver;
            loginPO = new LoginPO(_driver);
            detalheLeilaoPO = new DetalheLeilaoPO(_driver);
        }

        [Fact]
        public void QuandoLoginInteressadaDeveAtualizarLance()
        {
            //arrange
            loginPO.Visitar();
            loginPO.PreencherFormulario("leo@mail.com", "123");
            loginPO.SubmeteFormulario();

            detalheLeilaoPO.Visitar(1);

            //act '
            detalheLeilaoPO.OfertarLance(300);

            //assert
            Assert.True(detalheLeilaoPO.LanceCarregado());
        }
    }
}
