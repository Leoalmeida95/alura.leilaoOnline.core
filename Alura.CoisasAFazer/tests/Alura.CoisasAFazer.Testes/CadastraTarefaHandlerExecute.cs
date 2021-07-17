using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Microsoft.EntityFrameworkCore;
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
            var comando = new CadastraTarefa(titulo, new Categoria(1, "Estudo"), new DateTime(2019, 12, 31));

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                                .UseInMemoryDatabase("DBTarefasContext")
                                .Options;
            var context = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(context);
            var handler = new CadastraTarefaHandler(repo);

            //act
            handler.Execute(comando);

            //assert
            Assert.Single(repo.ObtemTarefas(a=>a.Titulo == titulo).ToList());
        }
    }
}
