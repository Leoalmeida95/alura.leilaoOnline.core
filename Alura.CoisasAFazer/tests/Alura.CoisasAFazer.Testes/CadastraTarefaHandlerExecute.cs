using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;
using Moq;

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

        [Fact]
        public void QuandoTarefaComInfoInvalidasNaoDeveIncluirNoBD()
        {
            //arrange
            var comando = new CadastraTarefa("", new Categoria(""), new DateTime(2222, 12, 31));

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                                .UseInMemoryDatabase("DBTarefasContext")
                                .Options;
            var context = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(context);
            var handler = new CadastraTarefaHandler(repo);

            //act
            handler.Execute(comando);

            //assert
            Assert.Empty(repo.ObtemTarefas(a => a.Titulo == "").ToList());
        }

        [Fact]
        public void QuandoTarefaComInfoInvalidasDeveLancarException()
        {
            //arrange
            var msg = "Título e Categoria da Tarefa não podem ser vazios";
            var comando = new CadastraTarefa("", new Categoria(""), new DateTime(2222, 12, 31));

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                                .UseInMemoryDatabase("DBTarefasContext")
                                .Options;
            var context = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(context);
            var handler = new CadastraTarefaHandler(repo);

            //act
            CommandResult resultado = handler.Execute(comando);

            //assert
            Assert.True(resultado.Mensagem == msg);
        }

        [Fact]
        public void QuandoExceptionForLancadaResultadoIsSuccessDeveSerFalse()
        {
            //arrange
            var comando = new CadastraTarefa("Estudar Testes", new Categoria(1, "Estudo"), new DateTime(2019, 12, 31));

            var mock = new Mock<IRepositorioTarefas>();
            mock
                .Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                .Throws(new Exception("Houve um erro ao incluir a tarefa"));
            var repo = mock.Object;

            var handler = new CadastraTarefaHandler(repo);

            //act
            CommandResult resultado = handler.Execute(comando);

            //assert
            Assert.False(resultado.IsSuccess);        
        }
    }
}
