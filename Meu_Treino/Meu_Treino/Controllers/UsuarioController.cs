using Meu_Treino.Enums;
using Meu_Treino.Filters;
using Meu_Treino.Models.Dtos;
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
        [PaginaLogado]
        public IActionResult Index()
        {
            return View();
        }
        [PaginaAdm]
        public IActionResult ListaUsuario()
        {
           List<Usuario> listaUsuario = _usuarioRepositorio.BuscaTodos();
            return View(listaUsuario);
        }

        //Cadastra os usuarios do site
        
        public IActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            PerfilEnum AcessoPerfil = new PerfilEnum();
            AcessoPerfil = (PerfilEnum)2;

            try
            {
                if (ModelState.IsValid)
                {
                    usuario.Perfil = AcessoPerfil;
                    usuario.DataCadastro = DateTime.Now;
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso!";
                    _usuarioRepositorio.Adicionar(usuario);
                    return View(usuario);
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, erro ao cadastrar o usuario. \nTente Novamente.\nErro: {erro.Message}";
                return View(usuario);

            }

        }

        // Busca os metodos para Apagar o usuario
        public IActionResult Login()
        {
            return View();
        }

        [PaginaAdm]
        public IActionResult Editar(int id)
        {             
            Usuario usuario = _usuarioRepositorio.BuscaId(id);
            return View(usuario); 
        }

        [PaginaAdm]
        [HttpPost]
        public IActionResult Alterar(Usuario usuario)
        {
            _usuarioRepositorio.Atualiza(usuario);
            return RedirectToAction("ListaUsuario");
        }
        [PaginaAdm]
        public IActionResult ApagarConfirma(int Id)
        {
            Usuario usuario = _usuarioRepositorio.BuscaId(Id);
            return View(usuario);
        }
        [PaginaAdm]
        public IActionResult ApagarUsuario(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.ApagarUsuario(id);
                if (apagado)
                    TempData["MensagemSucesso"] = "Usuário apacado com sucesso!";
                else
                    TempData["MensagemErro"] = "Usuário não apagado";

                return RedirectToAction("ListaUsuario", "Usuario");
            }

            catch (Exception ex)
            {

                TempData["Mensagemerro"] = $"Problemas em apagar o usuário. Erro: {ex.Message}";
                return RedirectToAction("ListaUsuario", "Usuario");
            }
        }

    }
}
