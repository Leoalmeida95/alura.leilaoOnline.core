using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LeilaoPO
    {
        private IWebDriver _driver;
        private By byInputTitulo;
        private By byInputDescricao;
        private By byClasseCategoria;
        private By byInputValorInicial;
        private By byInputImagem;
        private By byInputInicioPregao;
        private By byInputTerminoPregao;
        private By byBotaoSalvar;
        private By btTagSpan;

        public LeilaoPO(IWebDriver driver)
        {
            _driver = driver;
            byInputTitulo = By.Id("Titulo");
            byInputDescricao = By.Id("Descricao");
            byClasseCategoria = By.ClassName("select-dropdown");
            byInputValorInicial = By.Id("ValorInicial");
            byInputImagem = By.Id("ArquivoImagem");
            byInputInicioPregao = By.Id("InicioPregao");
            byInputTerminoPregao = By.Id("TerminoPregao");
            byBotaoSalvar = By.CssSelector("button[type=submit]");
            btTagSpan = By.TagName("span");
        }

        public void Visitar()
        {
            _driver.Navigate().GoToUrl("http://localhost:5000/Leiloes/Novo");
        }

        public void PreencherFormulario(string titulo, string descricao, string categoria, double valor, string imagem, DateTime inicio, DateTime termino)
        {
            _driver.FindElement(byInputTitulo).SendKeys(titulo);
            _driver.FindElement(byInputDescricao).SendKeys(descricao);
            _driver.FindElement(byInputValorInicial).SendKeys(valor.ToString());
            _driver.FindElement(byInputImagem).SendKeys(imagem);
            _driver.FindElement(byInputInicioPregao).SendKeys(inicio.ToString());
            _driver.FindElement(byInputTerminoPregao).SendKeys(termino.ToString());
            _driver.FindElement(byClasseCategoria).Click();
            _driver.FindElements(btTagSpan).Where(s => s.Text == categoria).First().Click();
        }

        public void SubmeteFormulario()
        {
            _driver.FindElement(byBotaoSalvar).Click();
        }
    }
}
