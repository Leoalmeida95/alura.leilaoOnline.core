using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuNaoLogadoPO
    {
        private IWebDriver _driver;

        public MenuNaoLogadoPO(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool MobileVisivel
        { get
            {
                return false;
            }
        }
    }
}
