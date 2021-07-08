using Microsoft.AspNetCore.Mvc.Filters;
using Alura.LeilaoOnline.WebApp.Extensions;
using Alura.LeilaoOnline.Core;
using Microsoft.AspNetCore.Mvc;

namespace Alura.LeilaoOnline.WebApp.Filtros
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var usuarioLogado = context.HttpContext.Session.Get<Usuario>("usuarioLogado");
            if (usuarioLogado == null)
            {
                context.Result = new RedirectToActionResult("Login", "Autenticacao", null);
            }
        }
    }
}
