using Meu_Treino.Data;
using Meu_Treino.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Meu_Treino.Repositorio
{
    public class ExercicioPlanoRepositorio : IExercicioPlanoRepositorio
    {
        private readonly MeuTreinoContext _context;
        public ExercicioPlanoRepositorio(MeuTreinoContext context)
        {
            _context = context;
        }
        public bool Apagar(int id)
        {
            ExerciciosPlano exerciciosPlanoDB = ListarId(id);

            if (exerciciosPlanoDB != null)
            {
                _context.ExerciciosPlanos.Remove(exerciciosPlanoDB);
                _context.SaveChanges();
            }
            else
            {
                // Lidar com a situação em que o objeto não foi encontrado
                throw new Exception("O objeto com o ID especificado não foi encontrado");
            }

            return true;
        }

        public ExerciciosPlano ListarId(int id)
        {
            return _context.ExerciciosPlanos.FirstOrDefault(x => x.Id == id);

        }
    }
}
