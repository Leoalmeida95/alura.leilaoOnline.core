using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Extensions
{
    public static class LeilaoExtensions
    {
        public static LeilaoViewModel ToViewModel(this Leilao leilao)
        {
            return new LeilaoViewModel
            {
                Id = leilao.Id,
                Titulo = leilao.Titulo,
                Descricao = leilao.Descricao,
                Categoria = leilao.Categoria,
                Imagem = leilao.Imagem,
                InicioPregao = leilao.InicioPregao,
                TerminoPregao = leilao.TerminoPregao,
                ValorInicial = leilao.ValorInicial,
                Estado = leilao.Estado,
                Lances = leilao.Lances
            };
        }

        public static Leilao ToModel(this LeilaoViewModel leilao)
        {
            return new Leilao(leilao.Titulo, null)
            {
                Id = leilao.Id,
                Titulo = leilao.Titulo,
                Descricao = leilao.Descricao,
                Categoria = leilao.Categoria,
                Imagem = leilao.Imagem,
                InicioPregao = leilao.InicioPregao,
                TerminoPregao = leilao.TerminoPregao,
                ValorInicial = leilao.ValorInicial
            };
        }
    }
}
