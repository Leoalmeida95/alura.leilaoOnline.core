using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public class RepositorioBase<T> : IRepositorio<T> where T:class
    {
        protected readonly LeiloesContext _ctx;

        public RepositorioBase(LeiloesContext context)
        {
            _ctx = context;
        }

        public virtual IEnumerable<T> Todos => _ctx.Set<T>();

        public virtual void Alterar(T obj)
        {
            _ctx.Update<T>(obj);
            _ctx.SaveChanges();
        }

        public virtual T BuscarPorId(int id)
        {
            return _ctx.Find<T>(id);
        }

        public virtual void Excluir(T obj)
        {
            _ctx.Remove<T>(obj);
            _ctx.SaveChanges();
        }

        public virtual void Incluir(T obj)
        {
            _ctx.Add<T>(obj);
            _ctx.SaveChanges();
        }
    }
}
