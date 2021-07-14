using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium
{
    [Collection("Chrome Drive")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;
        private RegistroPO registroPO;

        //Setup do teste
        public AoEfetuarRegistro(TestFixture _fixture)
        {
            driver = _fixture.driver;
            registroPO = new RegistroPO(driver);
        }

        [Theory]
        [InlineData("Leonardo A.", "leo@mail.com", "123", "123")]
        [InlineData("Ana Luiza", "ana@mail.com", "academia", "academia")]
        public void QuandoInfoValidasDeveIrApaginaAgradecimento(string nome, string email, string senha, string confSenha)
        {
            //arrange
            registroPO.Visitar();
            registroPO.PreencherFormulario(nome, email, senha, confSenha);

            //act 
            registroPO.SubmeteFormulario();

            //assert
            //registroPO.Esperar();
            Assert.Contains("Obrigado", driver.PageSource);
        }

        [Theory]
        [InlineData("a@", "a@mail.com", "academia", "aca3demia")]
        [InlineData("Leonardo", "leo", "123", "123")]
        [InlineData("Leonardo", "leo@mail.com", "123", "1234")]
        public void QuandoInfoInvalidasDeveManterNoRegistro(string nome, string email, string senha, string confSenha)
        {
            //arrange
            registroPO.Visitar();
            registroPO.PreencherFormulario(nome, email, senha, confSenha);

            //act 
            registroPO.SubmeteFormulario();

            //assert
            Assert.Contains("section-registro", driver.PageSource);
        }

        [Fact]
        public void QuandoNomeEmBrancoDeveMostrarMensagemErro()
        {
            //arrange
            registroPO.Visitar();

            //act 
            registroPO.SubmeteFormulario();

            //assert
            Assert.Equal("The Nome field is required.", registroPO.NomeMensagemErro);
        }

        [Fact]
        public void QuandoEmailInvalidoDeveMostrarMensagemErro()
        {
            //arrange
            registroPO.Visitar();
            registroPO.PreencherFormulario(string.Empty, "leo", string.Empty, string.Empty);

            //act 
            registroPO.SubmeteFormulario();

            //assert
            Assert.Equal("Please enter a valid email address.", registroPO.EmailMensagemErro);
        }
    }
}
