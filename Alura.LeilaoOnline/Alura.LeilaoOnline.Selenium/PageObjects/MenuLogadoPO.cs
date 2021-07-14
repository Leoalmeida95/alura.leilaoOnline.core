using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuLogadoPO
    {
        private IWebDriver _driver;
        private By byLogout;
        private By byMeuPerfil;

        public MenuLogadoPO(IWebDriver driver)
        {
            _driver = driver;
            byLogout = By.Id("logout");
            byMeuPerfil = By.Id("meu-perfil");
        }

        public void EfetuarLogout()
        {
            var logoutLink = _driver.FindElement(byLogout);
            var meuPerfilLink = _driver.FindElement(byMeuPerfil);

            //mover para o icon e posteriormente para o btnLogout
            IAction acaoLogout = new Actions(_driver)
                .MoveToElement(meuPerfilLink)
                .MoveToElement(logoutLink)
                .Click()
                .Build();

            acaoLogout.Perform();
        }
    }
}
