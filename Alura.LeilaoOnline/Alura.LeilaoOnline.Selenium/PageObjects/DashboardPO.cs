using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        }

        public void PesquisarLeiloes(List<string> cateogiras)
        {
            var selectWrapper = _driver.FindElement(bySelectCategorias);
            selectWrapper.Click();

            Thread.Sleep(2000);

            var opcoes = selectWrapper.FindElements(By.CssSelector("li>span"))
                                        .ToList();

            opcoes.ForEach(o =>
            {
                o.Click();
            });

            Thread.Sleep(2000);

            cateogiras.ForEach(cat =>
            {
                opcoes.Where(o=> o.Text.Contains(cat))
                .ToList()
                .ForEach(o=> {
                    o.Click();
                });
            });

            Thread.Sleep(2000);

            selectWrapper.FindElement(By.TagName("li"))
                .SendKeys(Keys.Tab);

            Thread.Sleep(2000);
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
