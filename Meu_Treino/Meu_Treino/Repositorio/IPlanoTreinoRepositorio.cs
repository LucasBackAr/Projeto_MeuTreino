using Meu_Treino.Models.Dtos;

namespace Meu_Treino.Repositorio
{
    public interface IPlanoTreinoRepositorio
    {
        List<PlanosTreino> GetPlanos();
        PlanosTreino Adicionar(PlanosTreino plano);
        PlanosTreino ListarId(int id);
        bool Apagar(int id);

    }
}
