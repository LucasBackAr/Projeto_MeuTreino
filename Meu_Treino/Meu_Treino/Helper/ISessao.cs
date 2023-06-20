using Meu_Treino.Models.Dtos;

namespace Meu_Treino.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario(Usuario usuario);
        void RemoveSessaoUsuario();
        Usuario BuscaSessaoUsusario();
    }
}
