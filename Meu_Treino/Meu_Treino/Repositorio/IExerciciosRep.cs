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
                
        Exercicio Adicionar(Exercicio exercicio);//Adiciona exercicios        
        Exercicio Atualiza(Exercicio exercicio); //Atualiz os dados do exercicio, caso preciso
        bool DeleteExercicio(int Id); //metodo para apagar o exerc
        List<Exercicio> BuscaTodosExercicios(); //Lista todos os exerc cadastrdos no sistema
        Exercicio BuscaExercioId(int id); //Buscas os exerc pela ID resolver
        IEnumerable<Exercicio> EncontrarPorNivelDifilcultade(string nivelDificuldade);//busca por nivel
    }
}
