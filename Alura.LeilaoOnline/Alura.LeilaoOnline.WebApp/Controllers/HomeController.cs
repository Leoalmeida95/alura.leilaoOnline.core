using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.Core;
using System.Linq;
using Alura.LeilaoOnline.WebApp.Extensions;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorio<Leilao> _repo;
        private readonly IRepositorio<Interessada> _repoInt;

        public HomeController(
            IRepositorio<Leilao> repositorio,
            IRepositorio<Interessada> repoInt)
        {
            _repo = repositorio;
            _repoInt = repoInt;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var proximosLeiloes = _repo.Todos
                .Where(l => l.Estado == EstadoLeilao.LeilaoAntesDoPregao)
                .OrderBy(l => l.InicioPregao)
                .Take(6)
                .Select(l => l.ToViewModel())
                .ToList();

            var usuarioLogado = HttpContext.Session.Get<Usuario>("usuarioLogado");

            if (usuarioLogado != null)
            {
                var interessada = _repoInt
                    .BuscarPorId(usuarioLogado.Interessada.Id);
                proximosLeiloes
                    .ForEach(l => l.SendoSeguido = interessada
                        .Favoritos
                        .Select(f => f.IdLeilao)
                        .Any(id => id == l.Id));
            }

            return View(proximosLeiloes);
        }

        [HttpGet]
        public IActionResult Detalhes(int id)
        {
            var leilao = _repo.BuscarPorId(id).ToViewModel();
            if (leilao != null)
            {
                var usuarioLogado = HttpContext.Session.Get<Usuario>("usuarioLogado");

                if (usuarioLogado != null)
                {
                    var interessada = _repoInt
                        .BuscarPorId(usuarioLogado.Interessada.Id);
                    leilao.SendoSeguido = interessada
                        .Favoritos
                        .Select(f => f.IdLeilao)
                        .Any(idLeilao => idLeilao == leilao.Id);
                }
                return View(leilao);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Categoria(string id)
        {
            ViewData["categoria"] = id;
            var leiloes = _repo.Todos
                .Where(l => l.Categoria == id)
                .Select(l => l.ToViewModel());
            return View("Index", leiloes);
        }

    }
}