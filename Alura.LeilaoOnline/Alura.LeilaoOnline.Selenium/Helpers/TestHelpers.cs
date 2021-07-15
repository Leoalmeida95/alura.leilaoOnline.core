using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public static class TestHelpers
    {
        public static ChromeDriver ObterDriver(ChromeOptions options = null)
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            return options != null ? new ChromeDriver(options) :  new ChromeDriver();
        }
    }
}
