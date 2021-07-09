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

        [Theory]
        [InlineData("Leonardo A.", "leo@mail.com", "123", "123")]
        [InlineData("Ana Luiza", "ana@mail.com", "academia", "academia")]
        public void QuandoInfoValidasDeveIrApaginaAgradecimento(string nome, string email, string senha, string confSenha)
        {
            //arrange
            driver.Navigate().GoToUrl("http://localhost:5000/");
            preencherFormulario(nome, email, senha, confSenha);

            //act 
            Registrar();

            //assert
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("obrigado")));
            Assert.Contains("Obrigado", driver.PageSource);
        }

        [Theory]
        [InlineData("", "ana@mail.com", "academia", "academia")]
        [InlineData("Leonardo", "leo", "123", "123")]
        [InlineData("Leonardo", "leo@mail.com", "123", "1234")]
        public void QuandoInfoInvalidasDeveManterNoRegistro(string nome, string email, string senha, string confSenha)
        {
            //arrange
            driver.Navigate().GoToUrl("http://localhost:5000/");
            preencherFormulario(nome, email, senha, confSenha);

            //act 
            Registrar();

            //assert
            Assert.Contains("section-registro", driver.PageSource);
        }

        #region métodos privados
        private void preencherFormulario(string nome, string email, string senha, string confSenha)
        {
            var inputNome = driver.FindElement(By.Id("Nome"));
            var inputEmail = driver.FindElement(By.Id("Email"));
            var inputSenha = driver.FindElement(By.Id("Password"));
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));

            inputNome.SendKeys(nome);
            inputEmail.SendKeys(email);
            inputSenha.SendKeys(senha);
            inputConfirmSenha.SendKeys(confSenha);
        }

        private void Registrar()
        {
            var btnRegistro = driver.FindElement(By.Id("btnRegistro"));
            btnRegistro.Click();
        }
        #endregion
    }
}
