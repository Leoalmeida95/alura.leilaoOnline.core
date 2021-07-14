using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Tests
{
    [Collection("Chrome Drive")]
    public class AoNavegarParaFormNovoLeilao
    {
        private IWebDriver driver;
        private LoginPO loginPO;
        private LeilaoPO leilaoPO;

        public AoNavegarParaFormNovoLeilao(TestFixture _fixture)
        {
            driver = _fixture.driver;
            loginPO = new LoginPO(driver);
            leilaoPO = new LeilaoPO(driver);
        }

        [Fact]
        public void QuandoLoginAdmDeveMostrarTresCategorias()
        {
            //arrange
            loginPO.EfetuarLogin("leo@mail.com", "123");

            //act
            leilaoPO.Visitar();

            //assert
            Assert.Equal(3, leilaoPO.Categorias.Count());
        }
    }

}
