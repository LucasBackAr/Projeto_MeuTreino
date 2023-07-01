using Meu_Treino.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Meu_Treino.ViewComponents
{
    public class ListaExerciciosViewComponent :ViewComponent
    {
        private readonly MeuTreinoContext _context;
        public ListaExerciciosViewComponent(MeuTreinoContext contexto)
        {
            _context = contexto;
        }

        public async Task<IViewComponentResult> InvokeAsync(int series)
        {
            return View(await _context.ExerciciosPlanos
                .OrderBy(t => t.Repeticoes).Where(t => t.Series == series).ToListAsync());
        } 
    }
}
