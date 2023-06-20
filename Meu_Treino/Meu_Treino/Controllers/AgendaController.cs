using Meu_Treino.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Meu_Treino.Controllers
{
    [PaginaLogado]
    public class AgendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
