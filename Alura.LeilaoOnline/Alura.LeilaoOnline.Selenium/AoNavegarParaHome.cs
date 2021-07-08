using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;

namespace Alura.LeilaoOnline.Selenium
{
    public class AoNavegarParaHome
    {
        [Fact]
        public void QuandoChromeAbertoDeveMostrarLeil�esNoTitulo()
        {
            //arrange
            var driver = TestHelpers.ObterDriver();
            
            //act 
            driver.Navigate().GoToUrl("http://localhost:5000/");

            //assert
            Assert.Contains("Leil�es", driver.Title);
        }

        [Fact]
        public void QuandoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //arrange
            var driver = TestHelpers.ObterDriver();

            //act 
            driver.Navigate().GoToUrl("http://localhost:5000/");

            //assert
            Assert.Contains("Pr�ximos Leil�es", driver.PageSource);
        }
    }
}
