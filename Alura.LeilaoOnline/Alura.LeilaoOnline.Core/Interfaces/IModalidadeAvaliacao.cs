using Alura.LeilaoOnline.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Core.Interfaces
{
    public interface IModalidadeAvaliacao
    {
        Lance Avalia(Leilao leilao);
    } 
}
