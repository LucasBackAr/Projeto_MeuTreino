using Meu_Treino.Models.Dtos;

namespace Meu_Treino.Repositorio
{       /// <summary>
        /// Responsavel pelos metodos usarios na classe Usuario. 
        /// Adicionar Usuario
        /// Listar Usuario
        /// BuscarUsuarios
        /// Atualizar e Apagar
        /// 
        /// </summary>
    public interface IExerciciosRep
    {
        List<Exercicio> GetExercicios();
        Exercicio ListarId(int id);
        Exercicio Adicionar(Exercicio exercicio);//Adiciona exercicios      

        bool Apagar(int id);
        
    }
}
