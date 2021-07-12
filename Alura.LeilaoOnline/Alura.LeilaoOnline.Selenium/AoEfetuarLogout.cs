using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium
{
    [Collection("Chrome Drive")]
    public class AoEfetuarLogout
    {
        private IWebDriver driver;
        private LoginPO loginPO;
        private DashboardPO dashPO;

        public AoEfetuarLogout(TestFixture _fixture)
        {
            driver = _fixture.driver;
            loginPO = new LoginPO(driver);
            dashPO = new DashboardPO(driver);
        }

        [Fact]
        public void QuandoLoginValiadoDeveIrParaHomeNaoLogada()
        {
            //arrange
            loginPO.Visitar();
            loginPO.PreencherFormulario("leo@mail.com", "123");
            loginPO.SubmeteFormulario();

            //act
            dashPO.EfetuarLogout();

            //assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}
