using Meu_Treino.Models.Dtos;

namespace Meu_Treino.Repositorio
{
    public interface IExercicioPlanoRepositorio
    {        
        bool Apagar(int id);
        ExerciciosPlano ListarId(int id);
    }
}
