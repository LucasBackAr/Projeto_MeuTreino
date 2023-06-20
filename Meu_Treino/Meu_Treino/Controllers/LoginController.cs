using Meu_Treino.Enums;
using Meu_Treino.Helper;
using Meu_Treino.Models.Dtos;
using Meu_Treino.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Meu_Treino.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao) 
        {
            _sessao = sessao;
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            //Se o usuario estiver logado, redireciiona para a Home;
            if (_sessao.BuscaSessaoUsusario() != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoveSessaoUsuario();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Usuario usuario = _usuarioRepositorio.BuscarLogin(loginModel.Login);

                    if(usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        
                        TempData["MensagemErro"] = $"Senha Inválida. Por Favor digite sua senha novamente.";
                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Usuário ou senha Inválido(s). Por Favor tente novamente.";
                    }
                    
                }
                return View("Index");

            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Digite realizar seu login. Erro: {erro.Message}";
                return View("Index");
            }


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
                    return View("Index");
                }

                return View("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, erro ao cadastrar o usuario. \nTente Novamente.\nErro: {erro.Message}";
                return View(usuario);

            }

        }

    }
}
