using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;

namespace Alura.LeilaoOnline.Selenium
{
    [Collection("Chrome Drive")]
    public class AoNavegarParaHome
    {
        private IWebDriver driver;

        //Setup do teste
        public AoNavegarParaHome(TestFixture _fixture)
        {
            driver = _fixture.driver;
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

        [Fact]
        public void QuandoAbrirFormRegisroNaoDeveHaverErros()
        {
            //arrange

            //act 
            driver.Navigate().GoToUrl("http://localhost:5000/");

            //assert
            var form = driver.FindElement(By.TagName("form"));
            var spans = form.FindElements(By.TagName("span"));

            spans.ToList().ForEach(s => Assert.True(string.IsNullOrEmpty(s.Text)));
        }
    }
}
