using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardPO
    {
        private IWebDriver _driver;
        private By byLogout;
        private By byMeuPerfil;

        public DashboardPO(IWebDriver driver)
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
