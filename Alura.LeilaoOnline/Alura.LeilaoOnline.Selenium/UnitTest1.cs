using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;

namespace Alura.LeilaoOnline.Selenium
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //arrange
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            ChromeDriver driver = new ChromeDriver();
            
            //act 
            driver.Navigate().GoToUrl("http://localhost:5000/");

            //assert
            Assert.Contains("Leilões", driver.Title);
        }
    }
}
