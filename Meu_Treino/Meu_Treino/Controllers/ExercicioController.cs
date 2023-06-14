using Microsoft.AspNetCore.Mvc;

namespace Meu_Treino.Controllers
{
    public class ExercicioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
