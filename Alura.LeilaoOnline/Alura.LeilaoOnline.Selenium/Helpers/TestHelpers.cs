using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public static class TestHelpers
    {
        public static ChromeDriver ObterDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver();
        }
    }
}
