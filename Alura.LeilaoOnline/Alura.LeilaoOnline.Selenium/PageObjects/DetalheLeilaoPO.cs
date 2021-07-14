using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DetalheLeilaoPO
    {
        private IWebDriver driver;
        private By byInputValor;
        private By byBotaoOfertar;
        private By byLanceAtual;

        public DetalheLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputValor = By.Id("Valor");
            byBotaoOfertar = By.Id("btnDarLance");
            byLanceAtual = By.Id("lanceAtual");
        }

        public double LanceAtual
        {
            get
            {
                var valorTexto = driver.FindElement(byLanceAtual).Text;
                return double.Parse(valorTexto, System.Globalization.NumberStyles.Currency);
            }
        }

        public void Visitar(int idLeilao)
        {
            driver.Navigate().GoToUrl($"http://localhost:5000/Home/Detalhes/{idLeilao}");
        }

        public void OfertarLance(int lance)
        {
            driver.FindElement(byInputValor).Clear();
            driver.FindElement(byInputValor).SendKeys(lance.ToString());
            driver.FindElement(byBotaoOfertar).Click();
        }

        public bool LanceCarregado()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            return wait.Until(drv => LanceAtual== 300);
        }
    }
}
