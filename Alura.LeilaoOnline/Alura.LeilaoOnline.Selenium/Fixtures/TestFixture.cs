using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    public class TestFixture : IDisposable
    {
        public IWebDriver driver { get; set; }

        //Setup
        public TestFixture()
        {
            var driver = TestHelpers.ObterDriver();
            driver.Manage().Window.Maximize();
            this.driver = driver;
        }

        //TearDown
        public void Dispose()
        {
            driver.Quit();
        }
    }
}
