using Meu_Treino.Data;
using Meu_Treino.Models.Dtos;

namespace Meu_Treino.Repositorio
{
    public class PlanosTreinoRepositorio : IPlanoTreinoRepositorio
    {
        private readonly MeuTreinoContext _context;

        public PlanosTreinoRepositorio(MeuTreinoContext contexto)
        {
            _context = contexto;
        }
        public PlanosTreino Adicionar(PlanosTreino plano)
        {
            _context.PlanosTreinos.Add(plano);
            _context.SaveChanges();
            return plano;
        }

        public bool Apagar(int id)
        {
            PlanosTreino planoDb = ListarId(id);

            if (planoDb != null)
            {
                _context.PlanosTreinos.Remove(planoDb);
                _context.SaveChanges();
            }
            else
            {
                throw new System.Exception("Houve um erro");
            }

            
            return true;
        }

        public List<PlanosTreino> GetPlanos()
        {
            return _context.PlanosTreinos.ToList();
        }

        public PlanosTreino ListarId(int id)
        {
            return _context.PlanosTreinos.FirstOrDefault(x => x.Id == id);
        }

        public List<PlanosTreino> PegarDatas()
        {
                DateTime dataAtual = DateTime.Now;
                DateTime dataEnd = DateTime.Now.AddDays(7);
                int qtdDias = 0;
                PlanosTreino datas;
                List<PlanosTreino> listaDatas = new List<PlanosTreino>();

                while (dataAtual < dataEnd)
                {
                    datas = new PlanosTreino();
                    datas.Datas = dataAtual.ToShortDateString();
                    datas.Identificadores = "collapse" + dataAtual.ToShortDateString().Replace("/", "");
                    listaDatas.Add(datas);
                    qtdDias++;
                    dataAtual = DateTime.Now.AddDays(qtdDias);
                }
                return listaDatas;
            
        }
    }
}
