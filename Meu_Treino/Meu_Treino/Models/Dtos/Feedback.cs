using System;
using System.Collections.Generic;

namespace Meu_Treino.Models.Dtos;

public partial class Feedback
{
    public int? UsuarioId { get; set; }

    public string? Comentario { get; set; }

    public int? Avaliacao { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
