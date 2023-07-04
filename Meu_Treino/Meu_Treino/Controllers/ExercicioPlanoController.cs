using Meu_Treino.Data;
using Meu_Treino.Models.Dtos;
using Meu_Treino.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Meu_Treino.Controllers
{
    public class ExercicioPlanoController : Controller
    {
        private readonly MeuTreinoContext _meuTreinoContext;
        private readonly IExercicioPlanoRepositorio _repositorio;
        public ExercicioPlanoController(MeuTreinoContext contexto,
                                        IExercicioPlanoRepositorio repositorio)
        {
            _meuTreinoContext = contexto;
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {

            var exerciciosPlano = _meuTreinoContext.ExerciciosPlanos
                .Include(ep => ep.Exercicio)
                .Include(ep => ep.Plano)
                .ToList();

            return View(exerciciosPlano);
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

            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id)
        {            
                 _repositorio.Apagar(id);
                return RedirectToAction("Index");            
            
        }


    }
}
