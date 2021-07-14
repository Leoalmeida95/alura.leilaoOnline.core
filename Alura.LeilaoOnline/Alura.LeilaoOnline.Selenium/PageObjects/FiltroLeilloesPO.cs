using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class FiltroLeilloesPO
    {
        private IWebDriver _driver;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaoPesquisar;

        public FiltroLeilloesPO(IWebDriver driver)
        {
            _driver = driver;
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
            if (emAndamento) _driver.FindElement(byInputAndamento).Click();

            _driver.FindElement(byBotaoPesquisar).Click();
        }
    }
}
