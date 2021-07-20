using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.CoisasAFazer.Services.Handlers
{
    public class CommandResult
    {
        public CommandResult(bool success, string mensagem = "")
        {
            IsSuccess = success;
            Mensagem = mensagem;
        }

        public string Mensagem { get; set; }
        public bool IsSuccess { get; set; }
    }
}
