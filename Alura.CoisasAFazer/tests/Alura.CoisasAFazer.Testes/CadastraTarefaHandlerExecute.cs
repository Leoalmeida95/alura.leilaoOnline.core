using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Services.Handlers;
using System;
using System.Linq;
using Xunit;

namespace Alura.CoisasAFazer.Testes
{
    public class CadastraTarefaHandlerExecute
    {
        [Fact]
        public void QuandoTarefaComInfoValidasDeveIncluirNoBD()
        {
            //arrange
            var titulo = "Estudar Testes";
            var comando = new CadastraTarefa(titulo, new Categoria("Estudo"), new DateTime(2019, 12, 31));
            var repo = new RepositorioFake();
            var handler = new CadastraTarefaHandler(repo);

            //act
            handler.Execute(comando);

            //assert
            Assert.Single(repo.ObtemTarefas(a=>a.Titulo == titulo).ToList());
        }
    }
}
