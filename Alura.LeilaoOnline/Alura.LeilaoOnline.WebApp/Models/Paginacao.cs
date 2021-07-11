using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Models
{

    public static class PaginacaoExtensions
    {
        public static Pagina<T> ToListaPaginada<T>(this IEnumerable<T> lista, Paginacao parametros)
        {
            var infoPagina = new Pagina
            {
                Anterior = parametros.Pagina - 1,
                Proxima = parametros.Pagina + 1,
                Atual = parametros.Pagina,
                TotalItens = lista.Count()
            };
            return new Pagina<T>
            {
                Info = infoPagina,
                Items = lista
                    .Skip(infoPagina.Anterior*parametros.Tamanho)
                    .Take(parametros.Tamanho)
                    .ToList()
            };
        }
    }

    public class Paginacao
    {
        public int Pagina { get; set; }
        public int Tamanho => 5;
    }

    public class Pagina
    {
        public int Atual { get; set; }
        public int Anterior { get; set; }
        public int Proxima { get; set; }
        public int TotalItens { get; set; }
    }

    public class Pagina<T>
    {
        public Pagina Info { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
