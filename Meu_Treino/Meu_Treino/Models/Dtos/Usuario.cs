using Meu_Treino.Enums;
using Meu_Treino.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Meu_Treino.Models.Dtos;
/// <summary>
/// Cria os Usuarios que serão cadastrados dentro do site.
/// Metodos para os usuarios.
/// </summary>
public class Usuario
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Digite o nome do Usuario")]
    public string Nome { get; set; } = null!;
    [Required(ErrorMessage = "Digite o Email do Usuario")]
    [EmailAddress(ErrorMessage = "O email informado não é válido")]
    public string Email { get; set; } = null!;
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Login { get; set; } = null!;

    //Vai tipificar os perfis de usuarios    
    public PerfilEnum Perfil { get; set; }
    [Required]
    public string Senha { get; set; } = null!;
    //public string ConfSenha { get; set; } = null!;


    //Le a Senha do usuario cripto
    public bool SenhaValida(string senha)
    {
        return Senha == senha.Cripritografia();
    }

    //cadastra a hora do usuario no BD
    public DateTime DataCadastro { get; set; }    

    public DateTime DataNascimento { get; set; }

    //Dado não obrigatorio
    public DateTime? DataAtualizacao { get; set; }

    //Dado não obrigatorio, para deixar isso a cargo do usuario que se identifica
    //ou não com algum genero.
    public string? Genero { get; set; }    

    //Vincula com o Pergil
    public virtual ICollection<Perfi> Perfis { get; set; } = new List<Perfi>();
    //Vincula com plano de treino
    public virtual ICollection<PlanosTreino> PlanosTreinos { get; set; } = new List<PlanosTreino>();

    // passa a cripto
    public void SetSenhaHash()
    {
        Senha = Senha.Cripritografia();
    }
}
