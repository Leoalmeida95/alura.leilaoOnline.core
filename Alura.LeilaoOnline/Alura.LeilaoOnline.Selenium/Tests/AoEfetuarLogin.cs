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
    public class AoEfetuarLogin
    {
        private IWebDriver driver;
        private LoginPO loginPO;

        public AoEfetuarLogin(TestFixture _fixture)
        {
            driver = _fixture.driver;
            loginPO = new LoginPO(driver);
        }

        [Fact]
        public void QuandoCredenciaisValidasDeveIrParaDashboard()
        {
            //arrange
            //act
            loginPO.EfetuarLogin("leo@mail.com", "123");

            //assert
            Assert.Contains("Dashboard", driver.Title);
        }

        [Fact]
        public void QuandoCredenciaisInvalidasDeveContinuarLogin()
        {
            //arrange
            //act
            loginPO.EfetuarLogin("leo@mail.com", "123444");

            //assert
            Assert.Contains("Login", driver.PageSource);
        }
    }
}
