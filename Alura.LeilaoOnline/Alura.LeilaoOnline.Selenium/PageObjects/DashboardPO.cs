using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardPO
    {
        private IWebDriver _driver;
        private By byLogout;

        public DashboardPO(IWebDriver driver)
        {
            _driver = driver;
            byLogout = By.Id("logout");
        }

        public void EfetuarLogout() 
        {
            var logoutLink = _driver.FindElement(byLogout);
        }
    }
}
