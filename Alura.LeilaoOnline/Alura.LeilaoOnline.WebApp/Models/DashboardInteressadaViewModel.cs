using Alura.LeilaoOnline.Core;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Models
{
    public class DashboardInteressadaViewModel
    {
        public IEnumerable<Lance> MinhasOfertas { get; set; }
        public IEnumerable<Leilao> LeiloesFavoritos { get; set; }
    }
}
