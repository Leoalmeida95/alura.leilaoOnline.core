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
    public class AoNavegarParaHome : IDisposable
    {
        private ChromeDriver driver;

        //Setup do teste
        public AoNavegarParaHome()
        {
            driver = TestHelpers.ObterDriver();
        }

        //TearDown
        public void Dispose()
        {
            driver.Quit();
        }

        [Fact]
        public void QuandoChromeAbertoDeveMostrarLeil�esNoTitulo()
        {
            //arrange
            
            //act 
            driver.Navigate().GoToUrl("http://localhost:5000/");

            //assert
            Assert.Contains("Leil�es", driver.Title);
        }

        [Fact]
        public void QuandoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //arrange

            //act 
            driver.Navigate().GoToUrl("http://localhost:5000/");

            //assert
            Assert.Contains("Pr�ximos Leil�es", driver.PageSource);
        }
    }
}
