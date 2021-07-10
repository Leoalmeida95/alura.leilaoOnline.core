using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class RegistroPO
    {
        private IWebDriver _driver;
        private By byInputNome;
        private By byInputEmail;
        private By byInputSenha;
        private By byInputConfSenha;
        private By byBtnRegistro;
        private By byFormRegistro;
        private By bySpanErroEmail;
        private By bySpanErroNome;
        private By byTextObrigado;

        public string EmailMensagemErro => _driver.FindElement(bySpanErroEmail).Text;
        public string NomeMensagemErro => _driver.FindElement(bySpanErroNome).Text;

        public RegistroPO(IWebDriver driver)
        {
            _driver = driver;
            byFormRegistro = By.TagName("form");
            byInputNome = By.Id("Nome");
            byInputEmail = By.Id("Email");
            byInputSenha = By.Id("Password");
            byInputConfSenha = By.Id("ConfirmPassword");
            byBtnRegistro = By.Id("btnRegistro");
            bySpanErroEmail = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");
            bySpanErroNome = By.CssSelector("span.msg-erro[data-valmsg-for=Nome]");
            byTextObrigado = By.Id("obrigado");
        }

        public void Visitar()
        {
            _driver.Navigate().GoToUrl("http://localhost:5000/");
        }

        public void SubmeteFormulario()
        {
            _driver.FindElement(byBtnRegistro).Click();
        }

        public void PreencherFormulario(string nome, string email, string senha, string confSenha)
        {
            _driver.FindElement(byInputNome).SendKeys(nome);
            _driver.FindElement(byInputEmail).SendKeys(email);
            _driver.FindElement(byInputSenha).SendKeys(senha);
            _driver.FindElement(byInputConfSenha).SendKeys(confSenha);
        }

        public void Esperar()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(10000));
            wait.Until(ExpectedConditions.ElementIsVisible(byTextObrigado));
        }
    }
}
