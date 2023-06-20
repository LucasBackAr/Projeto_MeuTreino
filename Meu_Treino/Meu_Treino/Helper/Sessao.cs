using Meu_Treino.Models.Dtos;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Meu_Treino.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public Sessao(IHttpContextAccessor contextAcessor)
        {
            _contextAccessor = contextAcessor;
        }
        public Usuario BuscaSessaoUsusario()
        {
            string sessaoUsuario = _contextAccessor.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if(string.IsNullOrEmpty(sessaoUsuario)) 
                return null;
            return JsonConvert.DeserializeObject<Usuario>(sessaoUsuario)!;

        }

        public void CriarSessaoUsuario(Usuario usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _contextAccessor.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoveSessaoUsuario()
        {
            _contextAccessor.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
