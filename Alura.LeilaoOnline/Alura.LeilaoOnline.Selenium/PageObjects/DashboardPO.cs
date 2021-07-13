using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardPO
    {
        private IWebDriver _driver;
        private By byLogout;
        private By byMeuPerfil;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaoPesquisar;


        public DashboardPO(IWebDriver driver)
        {
            _driver = driver;
            byLogout = By.Id("logout");
            byMeuPerfil = By.Id("meu-perfil");
            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Id("termo");
            byInputAndamento = By.ClassName("switch");
            byBotaoPesquisar = By.CssSelector("form>button.btn");
        }

        public void PesquisarLeiloes(List<string> cateogiras, string termo, bool emAndamento)
        {
            var select = new SelectMaterialize(_driver, bySelectCategorias);

            select.DeselectAll();

            cateogiras.ForEach(cat =>
            {
                select.SelectByText(cat);
            });

            _driver.FindElement(byInputTermo).SendKeys(termo);
            if(emAndamento) _driver.FindElement(byInputAndamento).Click();

            _driver.FindElement(byBotaoPesquisar).Click();
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
