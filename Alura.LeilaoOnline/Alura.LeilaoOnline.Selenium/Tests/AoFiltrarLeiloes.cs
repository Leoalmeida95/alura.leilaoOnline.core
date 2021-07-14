using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Tests
{
    [Collection("Chrome Drive")]
    public class AoFiltrarLeiloes
    {
        private IWebDriver driver;
        private LoginPO loginPO;
        private DashboardPO dashPO;


        public AoFiltrarLeiloes(TestFixture _fixture)
        {
            driver = _fixture.driver;
            loginPO = new LoginPO(driver);
            dashPO = new DashboardPO(driver);
        }

        [Fact]
        public void QuandoLoginInteressadaDeveMostrarPainelResultado()
        {
            //arrange
            loginPO.EfetuarLogin("leo@mail.com", "123");

            //act
            dashPO.Filtro.PesquisarLeiloes(new List<string>() { "Arte", "Automóveis" }, string.Empty, true);

            //assert
            Assert.Contains("Resultado da pesquisa", driver.PageSource);
        }
    }
}
