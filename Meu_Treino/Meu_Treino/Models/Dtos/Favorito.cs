using System;
using System.Collections.Generic;

namespace Meu_Treino.Models.Dtos;

public partial class Favorito
{
    public int? UsuarioId { get; set; }

    public int? ExercicioId { get; set; }

    public virtual Exercicio? Exercicio { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
