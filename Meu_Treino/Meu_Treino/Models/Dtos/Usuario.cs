using Meu_Treino.Enums;
using System;
using System.Collections.Generic;

namespace Meu_Treino.Models.Dtos;
/// <summary>
/// Cria os Usuarios que serão cadastrados dentro do site.
/// </summary>
public class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Login { get; set; } = null!;

    //Vai tipificar os perfis de usuarios
    public PerfilEnum Perfil { get; set; }

    public string Senha { get; set; } = null!;
    //public string ConfSenha { get; set; } = null!;

    public DateTime DataCadastro { get; set; }    

    public DateTime DataNascimento { get; set; }

    //Dado não obrigatorio
    public DateTime? DataAtualizacao { get; set; }

    //Dado não obrigatorio, para deixar isso a cargo do usuario que se identifica
    //ou não com algum genero.
    public string? Genero { get; set; }
    

    public virtual ICollection<Perfi> Perfis { get; set; } = new List<Perfi>();

    public virtual ICollection<PlanosTreino> PlanosTreinos { get; set; } = new List<PlanosTreino>();
}
