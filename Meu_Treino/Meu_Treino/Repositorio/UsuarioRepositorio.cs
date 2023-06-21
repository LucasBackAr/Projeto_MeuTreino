using Meu_Treino.Data;
using Meu_Treino.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Meu_Treino.Repositorio
{
    /// <summary>
    /// Cria repositorio dos usuarios no Banco de Dados.
    /// Grava o Usuario
    /// BuscaID
    /// Atualiza
    /// Le senha cripto
    /// </summary>
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly MeuTreinoContext _context;
        public UsuarioRepositorio() 
        {

        }
        public Usuario BuscarLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper())!;
        }
        public UsuarioRepositorio(MeuTreinoContext meuTreinoContext)
        { 
            _context = meuTreinoContext;
        }


        //grava no banco de dados os usuarios
        public Usuario Adicionar(Usuario usuario)
        {
            
            usuario.SetSenhaHash();
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;

        } 

        // Atualiza ususarios no BD
        public Usuario Atualiza(Usuario usuario)
        {
            
            Usuario usuarioDB = BuscaId(usuario.Id);
            if (usuarioDB == null)
                throw new Exception("Houve um erro na Atualização!");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;
            

            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }

        //Busca no Banco
        public Usuario BuscaId(int id)
        {            
            return _context.Usuarios.FirstOrDefault(x => x.Id == id)!;
        }
        
        //Apagar o Usuario
        public bool ApagarUsuario(int id)
        {
            Usuario usuarioDB = BuscaId(id);

            if (usuarioDB == null)
                throw new Exception("Houve um erro em apagar o usuário!");

            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges();
            return true;
        }


        public List<Usuario> BuscaTodos()
        {
            return _context.Usuarios.ToList();
        }
    }
}
