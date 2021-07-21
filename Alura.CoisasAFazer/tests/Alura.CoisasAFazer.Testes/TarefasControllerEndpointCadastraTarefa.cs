using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Alura.CoisasAFazer.WebApp.Controllers;
using Alura.CoisasAFazer.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Alura.CoisasAFazer.Services.Handlers;
using Alura.CoisasAFazer.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Alura.CoisasAFazer.Testes
{
    public class TarefasControllerEndpointCadastraTarefa
    {
        [Fact]
        public void QuandoTarefaComCategoriaInexisatenteDeveRetornar404()
        {
            //arrange
            var mockLog = new Mock<ILogger<CadastraTarefaHandler>>();

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                    .UseInMemoryDatabase("DBTarefasContext")
                    .Options;
            var context = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(context);

            var controlador = new TarefasController(repo, mockLog.Object);
            var model = new CadastraTarefaVM();
            model.IdCategoria = 20;
            model.Titulo = "Estudar";
            model.Prazo = DateTime.Now;

            //act
            var retorno = controlador.EndpointCadastraTarefa(model);

            //assert
            Assert.IsType<NotFoundObjectResult>(retorno);
        }
    }
}
