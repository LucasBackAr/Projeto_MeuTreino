using Meu_Treino.Filters;
using Meu_Treino.Models.Dtos;
using Meu_Treino.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Meu_Treino.Controllers
{
    [PaginaLogado]
    public class ExercicioController : Controller
    {
        private readonly IExerciciosRep _exerciciosRep;
        public ExercicioController(IExerciciosRep exercicioRepositorio)
        {
            _exerciciosRep = exercicioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarExercicio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarExercicio(Exercicio exercicio) 
        { 
             _exerciciosRep.Adicionar(exercicio);
            return View();
        }

    }
}
