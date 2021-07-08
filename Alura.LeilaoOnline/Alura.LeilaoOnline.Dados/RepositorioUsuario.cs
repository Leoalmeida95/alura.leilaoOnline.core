using Alura.LeilaoOnline.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public class RepositorioUsuario : RepositorioBase<Usuario>
    {
        public RepositorioUsuario(LeiloesContext ctx) : base(ctx)
        {

        }

        public override Usuario BuscarPorId(int id)
        {
            return _ctx.Usuarios
                .Include(u => u.Interessada)
                .FirstOrDefault(u => u.Id == id);
        }

    }
}
