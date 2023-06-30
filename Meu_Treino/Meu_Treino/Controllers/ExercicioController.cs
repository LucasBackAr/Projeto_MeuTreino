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

        [PaginaAdm]
        public IActionResult Index()
        {
            List<Exercicio> ListaExercicio =  _exerciciosRep.GetExercicios();
            return View(ListaExercicio);
        }

        public IActionResult CadastrarExercicio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarExercicio(Exercicio exercicio) 
        { 
             _exerciciosRep.Adicionar(exercicio);
            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                _exerciciosRep.Apagar(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Lidar com a exceção ou registrar o erro, conforme necessário
                return RedirectToAction("Error");
            }
        }

    }
}
