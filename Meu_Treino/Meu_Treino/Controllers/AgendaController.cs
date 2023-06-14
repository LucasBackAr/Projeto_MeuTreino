using Microsoft.AspNetCore.Mvc;

namespace Meu_Treino.Controllers
{
    public class AgendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
