using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Tests
{
    [Collection("Chrome Drive")]
    public class AoOfertarLance
    {
        private IWebDriver driver;

        public AoOfertarLance(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Fact]
        public void QuandoLoginInteressadaDeveAtualizarLance()
        {

        }
    }
}
