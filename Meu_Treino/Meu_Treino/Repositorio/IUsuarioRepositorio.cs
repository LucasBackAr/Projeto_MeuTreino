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
    public interface IUsuarioRepositorio
    {
        Usuario BuscarLogin(string login);
        Usuario Adicionar(Usuario usuario);
        List<Usuario> BuscaTodos(); //Lista todos os usuarios cadastrdos no sistema
        Usuario BuscaId(int id); //Buscas os usuarios pela ID resolver
        Usuario Atualiza(Usuario usuario); //Atualiz os dados do usuario, caso preciso
        bool ApagarUsuario(int Id); //metodo para apagar o usuario
    }
}
