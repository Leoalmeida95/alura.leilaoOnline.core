using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium
{
    [Collection("Chrome Drive")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        //Setup do teste
        public AoEfetuarRegistro(TestFixture _fixture)
        {
            driver = _fixture.driver;
        }

        [Fact]
        public void QuandoInfoValidasDeveIrApaginaAgradecimento()
        {
            //arrange
            driver.Navigate().GoToUrl("http://localhost:5000/");
            var inputNome = driver.FindElement(By.Id("Nome"));
            var inputEmail = driver.FindElement(By.Id("Email"));
            var inputSenha = driver.FindElement(By.Id("Password"));
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));

            inputNome.SendKeys("Leonardo A.");
            inputEmail.SendKeys("leo@mail.com");
            inputSenha.SendKeys("123");
            inputConfirmSenha.SendKeys("123");

            var btnRegistro = driver.FindElement(By.Id("btnRegistro"));

            //act 
            btnRegistro.Click();

            //assert
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("obrigado")));
            Assert.Contains("Obrigado", driver.PageSource);
        }
    }
}
