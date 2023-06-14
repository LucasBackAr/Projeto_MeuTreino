using Meu_Treino.Models.Dtos;
using Meu_Treino.Models.Interface;
using Meu_Treino.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Meu_Treino.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListaUsuario()
        {
           List<Usuario> listaUsuario = _usuarioRepositorio.BuscaTodos();
            return View(listaUsuario);
        }
        public IActionResult Cadastro()
        {
            return View();
        }
      
        public IActionResult ApagarUsuario()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            usuario.DataCadastro = DateTime.Today;
            _usuarioRepositorio.Adicionar(usuario);
            return RedirectToAction("Index", "Home");
        }
       
        public IActionResult Editar(int id)
        {
            Usuario usuario = _usuarioRepositorio.BuscaId(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Alterar(Usuario usuario)
        {
            _usuarioRepositorio.Atualiza(usuario);
            return RedirectToAction("ListaUsuario");
        }

    }
}
