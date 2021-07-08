using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Models
{
    public class Paginacao
    {

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
