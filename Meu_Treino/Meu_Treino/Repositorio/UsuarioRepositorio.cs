using Meu_Treino.Data;
using Meu_Treino.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Meu_Treino.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly MeuTreinoContext _context;
        public UsuarioRepositorio() 
        {

        }
        public UsuarioRepositorio(MeuTreinoContext meuTreinoContext)
        { 
            _context = meuTreinoContext;
        }

        public Usuario Adicionar(Usuario usuario)
        {
            //Grava no bando de dados
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;

        }       
        

        public bool Apagar(int id)
        {
            Usuario usuarioDB = BuscaId(id);

            if (usuarioDB == null)
                throw new Exception("Houve um erro em apagar o usuário!");

            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges();

            return true;
        }

        public Usuario Atualiza(Usuario usuario)
        {
            
            Usuario usuarioDB = BuscaId(usuario.Id);
            if (usuarioDB == null)
                throw new Exception("Houve um erro na Atualização!");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuario.Login = usuario.Login;

            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }

        public Usuario BuscaId(int id)
        {            
            return _context.Usuarios.FirstOrDefault(x => x.Id == id)!;
        }

        public List<Usuario> BuscaTodos()
        {
            return _context.Usuarios.ToList();
        }
    }
}
