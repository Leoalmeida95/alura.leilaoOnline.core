using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;
using Moq;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;

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

            var mock = new Mock<ILogger<CadastraTarefaHandler>>();

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                                .UseInMemoryDatabase("DBTarefasContext")
                                .Options;
            var context = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(context);
            var handler = new CadastraTarefaHandler(repo, mock.Object);

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

            var mock = new Mock<ILogger<CadastraTarefaHandler>>();
            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                                .UseInMemoryDatabase("DBTarefasContext")
                                .Options;
            var context = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(context);
            var handler = new CadastraTarefaHandler(repo, mock.Object);

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

            var mock = new Mock<ILogger<CadastraTarefaHandler>>();
            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                                .UseInMemoryDatabase("DBTarefasContext")
                                .Options;
            var context = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(context);
            var handler = new CadastraTarefaHandler(repo, mock.Object);

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

            var mockLog = new Mock<ILogger<CadastraTarefaHandler>>();
            var mock = new Mock<IRepositorioTarefas>();
            mock
                .Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                .Throws(new Exception("Houve um erro ao incluir a tarefa"));
            var repo = mock.Object;

            var handler = new CadastraTarefaHandler(repo, mockLog.Object);

            //act
            CommandResult resultado = handler.Execute(comando);

            //assert
            Assert.False(resultado.IsSuccess);        
        }

        [Fact]
        public void QuandoRegistroCorretoResultadoIsSuccessDeveSerTrue()
        {
            //arrange
            var comando = new CadastraTarefa("Estudar Testes", new Categoria(1, "Estudo"), new DateTime(2019, 12, 31));

            var mockLog = new Mock<ILogger<CadastraTarefaHandler>>();
            var mock = new Mock<IRepositorioTarefas>();
            var repo = mock.Object;

            var handler = new CadastraTarefaHandler(repo, mockLog.Object);

            //act
            CommandResult resultado = handler.Execute(comando);

            //assert
            Assert.True(resultado.IsSuccess);
        }

        [Fact]
        public void QuandoExceptionForLancadaDeveLogarAMensagemDaException()
        {
            //arrange
            var excpt = new Exception("Houve um erro ao incluir a tarefa");
            var comando = new CadastraTarefa("Estudar Testes", new Categoria(1, "Estudo"), new DateTime(2019, 12, 31));

            var mockLog = new Mock<ILogger<CadastraTarefaHandler>>();
            var mock = new Mock<IRepositorioTarefas>();
            mock
                .Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                .Throws(excpt);
            var repo = mock.Object;

            var handler = new CadastraTarefaHandler(repo, mockLog.Object);

            //act
            CommandResult resultado = handler.Execute(comando);

            //assert
            mockLog.Verify(l => l.Log(
                                            LogLevel.Error, //LogError
                                            It.IsAny<EventId>(), //identificador evento error
                                            It.IsAny<object>(), //objeto que será logado
                                            excpt, //excecao que sera logada
                                            It.IsAny<Func<object, Exception, string>>() //funcao que converte objeto + excpt > string
                                       ),Times.Once());
        }

        [Fact]
        public void QuandoTarefaComInfoValidasDeveLogar()
        {
            //arrange
            var titulo = "Estudar Testes";
            var comando = new CadastraTarefa(titulo, new Categoria(1, "Estudo"), new DateTime(2019, 12, 31));

            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();


            LogLevel levelCapturado = LogLevel.Error;
            string mensagemCapturada = string.Empty;

            CapturaMensagemLog captura = (level, eventId, state, exception, func) =>
            {
                levelCapturado = level;
                mensagemCapturada = func(state, exception);
            };

            mockLogger.Setup(l => l.Log(
                                            It.IsAny<LogLevel>(),
                                            It.IsAny<EventId>(),
                                            It.IsAny<object>(),
                                            It.IsAny<Exception>(),
                                            It.IsAny<Func<object, Exception, string>>()
                                       )).Callback(captura);

            var mock = new Mock<IRepositorioTarefas>();

            var handler = new CadastraTarefaHandler(mock.Object, mockLogger.Object);

            //act
            handler.Execute(comando);

            //assert
            Assert.Equal(LogLevel.Debug, levelCapturado);
            Assert.Contains(titulo, mensagemCapturada);
        }

        #region
        delegate void CapturaMensagemLog(LogLevel level, EventId eventId, object state, Exception exception, Func<object, Exception, string> func);
        #endregion
    }
}
