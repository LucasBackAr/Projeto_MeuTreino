using Meu_Treino.Models.Dtos;
using Meu_Treino.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Meu_Treino.Controllers
{
    public class PlanoTreinoController : Controller
    {
        private readonly IPlanoTreinoRepositorio _planosRepositorio;
        public PlanoTreinoController(IPlanoTreinoRepositorio planosrepositorio)
        {
            _planosRepositorio = planosrepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(PlanosTreino plano)
        {
            _planosRepositorio.Adicionar(plano);
            return View();
        }

    }
}
