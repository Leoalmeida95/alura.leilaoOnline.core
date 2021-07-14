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


        public FiltroLeilloesPO Filtro { get; }
        public MenuLogadoPO Menu { get; }


        public DashboardPO(IWebDriver driver)
        {
            _driver = driver;

            Filtro = new FiltroLeilloesPO(driver);
            Menu = new MenuLogadoPO(driver);
        }
    }
}
