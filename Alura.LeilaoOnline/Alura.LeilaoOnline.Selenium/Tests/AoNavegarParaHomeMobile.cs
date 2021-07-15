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
            var options = new ChromeOptions();
            options.EnableMobileEmulation(new ChromeMobileEmulationDeviceSettings { Width = 400, Height = 800, UserAgent = "Customizada" });
            driver = TestHelpers.ObterDriver(options);
            homeNaoLogadaPO = new HomeNaoLogadaPO(driver);
        }

        [Fact]
        public void QuandoLarguraFor400DeveMostrarMenuMobile()
        {
            //arrange

            //act
            homeNaoLogadaPO.Visitar();

            //assert
            Assert.True(homeNaoLogadaPO.Menu.MobileVisivel);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
