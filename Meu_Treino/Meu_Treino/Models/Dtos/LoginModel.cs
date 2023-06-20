using System.ComponentModel.DataAnnotations;

namespace Meu_Treino.Models.Dtos
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite seu nome de usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite sua senha corretamente")]
        public string Senha { get; set; }
    }
}
