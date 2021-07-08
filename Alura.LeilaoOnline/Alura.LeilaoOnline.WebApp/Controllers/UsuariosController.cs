using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IRepositorio<Usuario> _repo;

        public UsuariosController(IRepositorio<Usuario> repositorio)
        {
            _repo = repositorio;
        }

        [HttpPost]
        public IActionResult Registro(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                //registrar usuário/interessado
                var usuario = new Usuario { Email = model.Email, Senha = model.Password, Interessada = new Interessada(model.Nome) };
                _repo.Incluir(usuario);
                return RedirectToAction("Agradecimento");
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Agradecimento()
        {
            return View();
        }
    }
}