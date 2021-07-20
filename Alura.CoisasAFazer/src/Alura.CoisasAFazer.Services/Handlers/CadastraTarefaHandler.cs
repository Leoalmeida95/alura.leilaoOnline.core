using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Infrastructure;
using System;
using Microsoft.Extensions.Logging;

namespace Alura.CoisasAFazer.Services.Handlers
{
    public class CadastraTarefaHandler
    {
        IRepositorioTarefas _repo;
        ILogger<CadastraTarefaHandler> _logger;

        public CadastraTarefaHandler(IRepositorioTarefas repositorio)
        {
            _repo = repositorio;
            _logger = new LoggerFactory().CreateLogger<CadastraTarefaHandler>();
        }

        public CommandResult Execute(CadastraTarefa comando)
        {
            try
            {
                if (comando.Titulo == string.Empty || comando.Categoria.Descricao == string.Empty) throw new Exception("Título e Categoria da Tarefa não podem ser vazios");

                var tarefa = new Tarefa
                (
                    id: 0,
                    titulo: comando.Titulo,
                    prazo: comando.Prazo,
                    categoria: comando.Categoria,
                    concluidaEm: null,
                    status: StatusTarefa.Criada
                );

                _logger.LogDebug("Persistindo a tarefa...");
                _repo.IncluirTarefas(tarefa);

                return new CommandResult(true);
            }
            catch (Exception e)
            {
                return new CommandResult(false, e.Message);
            }
        }
    }
}
