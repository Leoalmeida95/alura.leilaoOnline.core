using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Selenium
{
    [Collection("Chrome Drive")]
    public class AoCriarLeilao
    {
        private IWebDriver driver;
        private LoginPO loginPO;
        private LeilaoPO leilaoPO;

        public AoCriarLeilao(TestFixture _fixture)
        {
            driver = _fixture.driver;
            loginPO = new LoginPO(driver);
            leilaoPO = new LeilaoPO(driver);
        }

        [Theory]
        [InlineData("VENDA CARRO", "Novíssimo", "Arte e Pintura", 10000, @"C:\Users\leonardo.silva\Pictures\Screenshots\1.png", "2021-05-20", "2021-05-21")]
        public void QuandoLoginAdminEInfoValidasDeveCadastrarLeilao(string titulo, string descricao, string categoria, double valor, string imagem, string inicio, string termino)
        {
            //arrange
            loginPO.Visitar();
            loginPO.PreencherFormulario("leo@mail.com", "123");
            loginPO.SubmeteFormulario();

            leilaoPO.Visitar();
            leilaoPO.PreencherFormulario(titulo, descricao, categoria, valor, imagem, Convert.ToDateTime(inicio), Convert.ToDateTime(termino));

            //act
            leilaoPO.SubmeteFormulario();

            //assert
            Assert.Contains("Leilões cadastrados", driver.PageSource);
        }
    }
}
