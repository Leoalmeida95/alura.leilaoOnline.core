using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Tests
{
    public class AoNavegarParaHomeMobile : IDisposable
    {
        private ChromeDriver driver;
        private HomeNaoLogadaPO homeNaoLogadaPO;

        public AoNavegarParaHomeMobile()
        {
        }

        [Fact]
        public void QuandoLarguraFor992DeveMostrarMenuMobile()
        {
            //arrange
            var options = new ChromeOptions();
            options.EnableMobileEmulation(new ChromeMobileEmulationDeviceSettings { Width = 992, Height = 800, UserAgent = "Customizada" });
            driver = TestHelpers.ObterDriver(options);
            homeNaoLogadaPO = new HomeNaoLogadaPO(driver);

            //act
            homeNaoLogadaPO.Visitar();

            //assert
            Assert.True(homeNaoLogadaPO.Menu.MobileVisivel);
        }

        [Fact]
        public void QuandoLarguraFor993NaoDeveMostrarMenuMobile()
        {
            //arrange
            var options = new ChromeOptions();
            options.EnableMobileEmulation(new ChromeMobileEmulationDeviceSettings { Width = 993, Height = 800, UserAgent = "Customizada" });
            driver = TestHelpers.ObterDriver(options);
            homeNaoLogadaPO = new HomeNaoLogadaPO(driver);

            //act
            homeNaoLogadaPO.Visitar();

            //assert
            Assert.False(homeNaoLogadaPO.Menu.MobileVisivel);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
