using Alura.LeilaoOnline.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public class RepositorioLeilao : RepositorioBase<Leilao>
    {
        public RepositorioLeilao(LeiloesContext context): base(context) { }

        public override Leilao BuscarPorId(int id)
        {
            return _ctx.Leiloes
                .Include(l => l.Lances)
                .Include(l => l.Seguidores)
                .FirstOrDefault(l => l.Id == id);
        }
    }
}
