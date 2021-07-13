using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class HomePO
    {
        private IWebDriver _driver;

        public HomePO(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Visitar()
        {
            _driver.Navigate().GoToUrl("http://localhost:5000/Home/Categoria");
        }
    }
}
