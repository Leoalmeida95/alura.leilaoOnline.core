using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LoginPO
    {
        private IWebDriver _driver;
        private By byInputLogin;
        private By byInputSenha;
        private By byBotaoLogin;

        public LoginPO(IWebDriver driver)
        {
            _driver = driver;
            byInputLogin = By.Id("Login");
            byInputSenha = By.Id("Password");
            byBotaoLogin = By.Id("btnLogin");
        }

        public void Visitar()
        {
            _driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
        }

        public void PreencherFormulario(string login, string senha)
        {
            _driver.FindElement(byInputLogin).SendKeys(login);
            _driver.FindElement(byInputSenha).SendKeys(senha);
        }

        public void SubmeteFormulario()
        {
            _driver.FindElement(byBotaoLogin).Submit();
        }
    }
}
