using Meu_Treino.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Meu_Treino.Filters
{
    public class PaginaLogado : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary 
                { 
                    {"controller","Login" }, {"action","Index"}
                });
            }
            else
            {
                Usuario usuario = JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);
                
                if (usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller","Login" }, {"action","Index"}
                });

                }
            }

            base.OnActionExecuted(context);
        }
    }
}
