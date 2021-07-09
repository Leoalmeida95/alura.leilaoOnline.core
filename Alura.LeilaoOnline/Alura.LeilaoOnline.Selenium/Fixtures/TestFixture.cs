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
            driver = TestHelpers.ObterDriver();
        }

        //TearDown
        public void Dispose()
        {
            driver.Quit();
        }
    }
}
