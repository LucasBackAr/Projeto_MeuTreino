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

        public Exercicio ListarId(int id)
        {
            return _context.Exercicios.FirstOrDefault(x => x.Id == id);

        }

        public Exercicio Adicionar(Exercicio exercicio)
        {
            _context.Exercicios.Add(exercicio);
            _context.SaveChanges();
            return exercicio;
            
        }

        public bool Apagar(int id)
        {
            Exercicio exercicioDB = ListarId(id);

            if (exercicioDB != null)
            {
                _context.Exercicios.Remove(exercicioDB);
                _context.SaveChanges();
            }
            else
            {
                throw new System.Exception("Houve um erro");
            }            
            return true;
        }

        public List<Exercicio> GetExercicios()
        {
            return _context.Exercicios.ToList();
        }

        
    }
}
