using Meu_Treino.Data;
using Meu_Treino.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Meu_Treino.Repositorio
{
    /// <summary>
    /// Cria repositorio dos exerc no Banco de Dados.
    /// Grava o Exerc
    /// BuscaID
    /// Atualiza
    /// </summary>
    public class ExerciciosRep : IExerciciosRep
    {
        private readonly MeuTreinoContext _context;
        public ExerciciosRep(MeuTreinoContext meuTreinoContext)
        {
            _context = meuTreinoContext;
        }
        public Exercicio Adicionar(Exercicio exercicio)
        {
            _context.Exercicios.Add(exercicio);
            _context.SaveChanges();
            return exercicio;
            
        }

        public List<Exercicio> GetExercicios()
        {
            return _context.Exercicios.ToList();
        }
    }
}
