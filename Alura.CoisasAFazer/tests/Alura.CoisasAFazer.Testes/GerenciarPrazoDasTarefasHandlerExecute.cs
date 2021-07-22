using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Alura.CoisasAFazer.Testes
{
    public class GerenciarPrazoDasTarefasHandlerExecute
    {
        private List<Tarefa> tarefas;
        private List<Categoria> categorias;

        public GerenciarPrazoDasTarefasHandlerExecute()
        {
            categorias = new List<Categoria>();
            tarefas = new List<Tarefa>();
        }

        [Fact]
        public void QuandoTarefasEstiveremAtrasadasDeveMudarSeuStatus()
        {
            //arrange
            CriarCategorias();
            CriarTarefas();
            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                                .UseInMemoryDatabase("DBTarefasContext")
                                .Options;
            var context = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(context);
            repo.IncluirTarefas(tarefas.ToArray());

            var comando = new GerenciaPrazoDasTarefas(new DateTime(2020, 07, 16));
            var handler = new GerenciaPrazoDasTarefasHandler(repo);
            //act
            handler.Execute(comando);

            //assert
            var tarefasAtrasada = repo.ObtemTarefas(t => t.Status == StatusTarefa.EmAtraso);
            Assert.Equal(5, tarefasAtrasada.Count());
        }

        [Fact]
        public void QuandoTarefasNaoAtrasadasDevePermanecerSeuStatus()
        {
            //arrange
            CriarCategorias();
            CriarTarefas();
            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                                .UseInMemoryDatabase("DBTarefasContext")
                                .Options;
            var context = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(context);
            repo.IncluirTarefas(tarefas.ToArray());

            var comando = new GerenciaPrazoDasTarefas(new DateTime(2020, 07, 16));
            var handler = new GerenciaPrazoDasTarefasHandler(repo);
            //act
            handler.Execute(comando);

            //assert
            var tarefasAtrasada = repo.ObtemTarefas(t => t.Status == StatusTarefa.EmAtraso);
            Assert.Equal(5, tarefasAtrasada.Count());
        }

        [Fact]
        public void QuandoInvocadoDeveChamarAtualizarTarefasApenasUmaVezIndependenteDaQtdDeTarefas()
        {
            //arrange
            CriarCategorias();
            CriarTarefas();
            var mock = new Mock<IRepositorioTarefas>();
            mock.Setup(r => r.ObtemTarefas(It.IsAny<Func<Tarefa, bool>>()))
                .Returns(tarefas);

            var repo = mock.Object;
            var comando = new GerenciaPrazoDasTarefas(new DateTime(2020, 07, 16));
            var handler = new GerenciaPrazoDasTarefasHandler(repo);

            //act
            handler.Execute(comando);

            //assert
            mock.Verify(r => r.AtualizarTarefas(It.IsAny<Tarefa[]>()), Times.Once());
        }

        private void CriarCategorias()
        {
            categorias.Add(new Categoria(6, "Compras"));
            categorias.Add(new Categoria(2, "Casa"));
            categorias.Add(new Categoria(3, "Trabalho"));
            categorias.Add(new Categoria(4, "Saúde"));
            categorias.Add(new Categoria(5, "Higiene"));
        }

        private void CriarTarefas()
        {
            tarefas.Add(new Tarefa(30, "Tirar lixo", categorias.Where(a => a.Descricao == "Casa").First(), new DateTime(2020, 07, 10), null, StatusTarefa.Criada));
            tarefas.Add(new Tarefa(4, "Fazer o almoço", categorias.Where(a => a.Descricao == "Casa").First(), new DateTime(2020, 07, 10), null, StatusTarefa.Criada));
            tarefas.Add(new Tarefa(9, "Ir à academia", categorias.Where(a => a.Descricao == "Saúde").First(), new DateTime(2020, 07, 10), null, StatusTarefa.Criada));
            tarefas.Add(new Tarefa(7, "Concluir o relatório", categorias.Where(a => a.Descricao == "Trabalho").First(), new DateTime(2020, 07, 10), null, StatusTarefa.Pendente));
            tarefas.Add(new Tarefa(10, "Beber água", categorias.Where(a => a.Descricao == "Saúde").First(), new DateTime(2020, 07, 10), null, StatusTarefa.Criada));
            tarefas.Add(new Tarefa(8, "Comparecer à reunião", categorias.Where(a => a.Descricao == "Trabalho").First(), new DateTime(2020, 07, 15), null, StatusTarefa.Concluida));
            tarefas.Add(new Tarefa(2, "Arrumar a cama", categorias.Where(a => a.Descricao == "Casa").First(), new DateTime(2020, 07, 17), null, StatusTarefa.Criada));
            tarefas.Add(new Tarefa(3, "Escovar os dentes", categorias.Where(a => a.Descricao == "Higiene").First(), new DateTime(2020, 07, 17), null, StatusTarefa.Criada));
            tarefas.Add(new Tarefa(5, "Comprar presente pra Ana", categorias.Where(a => a.Descricao == "Compras").First(), new DateTime(2020, 07, 17), null, StatusTarefa.Criada));
            tarefas.Add(new Tarefa(6, "Compra ração", categorias.Where(a => a.Descricao == "Compras").First(), new DateTime(2020, 07, 17), null, StatusTarefa.Criada));
        }
    }
}
