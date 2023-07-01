using Meu_Treino.Data;
using Meu_Treino.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Meu_Treino.Controllers
{
    public class ExercicioPlanoController : Controller
    {
        private readonly MeuTreinoContext _meuTreinoContext;
        public ExercicioPlanoController(MeuTreinoContext contexto)
        {
            _meuTreinoContext = contexto;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult CriarExercicioPlano(string dataPlano)
        {
            var exercicio = _meuTreinoContext.Exercicios.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Nome
            });

            var planos = _meuTreinoContext.PlanosTreinos.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.NomePlano
            });

            var viewModel = new ExerciciosPlano
            {
                Exercicios = exercicio,
                Planos = planos
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CriarExercicioPlano(ExerciciosPlano viewModel)
        {
            var exercicioPlano = new ExerciciosPlano
            {
                PlanoId = viewModel.SelectedPlanoId,
                ExercicioId = viewModel.SelectedExerciseId,
                Repeticoes = viewModel.Repeticoes,
                Series = viewModel.Series
            };

            _meuTreinoContext.ExerciciosPlanos.Add(exercicioPlano);
            _meuTreinoContext.SaveChanges();

            return RedirectToAction("Planos", "PlanoTreino");
        }
    }
}
