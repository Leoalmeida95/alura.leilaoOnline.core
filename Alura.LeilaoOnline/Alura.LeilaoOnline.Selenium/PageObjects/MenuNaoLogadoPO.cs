using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuNaoLogadoPO
    {
        private IWebDriver _driver;
        private By byMenuMobile;

        public MenuNaoLogadoPO(IWebDriver driver)
        {
            _driver = driver;
            byMenuMobile = By.ClassName("sidenav-trigger");
        }

        public bool MobileVisivel
        { get
            {
                return _driver.FindElement(byMenuMobile).Displayed;
            }
        }
    }
}
