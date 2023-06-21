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
    /// Le senha cripto
    /// </summary>
    public class ExerciciosRep : IExerciciosRep
    {
        private readonly MeuTreinoContext _context;
        public ExerciciosRep(MeuTreinoContext meuTreinoContext)
        {
            _context = meuTreinoContext;
        }
        public Exercicio Add(Exercicio exercicio)
        {
            _context.Exercicios.Add(exercicio);
            _context.SaveChanges();
            return exercicio;
        }

        public Exercicio Atualiza(Exercicio exercicio)
        {
            Exercicio exercicioDB = BuscaExercioId(exercicio.Id);
            if (exercicioDB == null)
                throw new Exception("Houve um erro na Atualização!");

            exercicioDB.Nome = exercicio.Nome;
            exercicioDB.Descricao = exercicio.Descricao;
            exercicioDB.NivelDificuldade = exercicio.NivelDificuldade; 
            exercicioDB.GrupoMuscular = exercicio.GrupoMuscular;
            exercicioDB.Instrucoes = exercicio.Instrucoes;
           


            _context.Exercicios.Update(exercicioDB);
            _context.SaveChanges();

            return exercicioDB;
        }

        public Exercicio BuscaExercioId(int id)
        {
            return _context.Exercicios.FirstOrDefault(x => x.Id == id)!;
        }

        public List<Exercicio> BuscaTodosExercicios()
        {
            return _context.Exercicios.ToList();
        }

        public bool DeleteExercicio(int id)
        {
            Exercicio exercicioDB = BuscaExercioId(id);

            if (exercicioDB == null)
                throw new Exception("Houve um erro em apagar o usuário!");

            _context.Exercicios.Remove(exercicioDB);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Exercicio> EncontrarPorNivelDifilcultade(string nivelDificuldade)
        {
            return _context.Exercicios.Where( e => e.NivelDificuldade == nivelDificuldade).ToList();
        }
    }
}
