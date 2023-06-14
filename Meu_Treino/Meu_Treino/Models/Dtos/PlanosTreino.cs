using System;
using System.Collections.Generic;

namespace Meu_Treino.Models.Dtos;

public partial class PlanosTreino
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public string NomePlano { get; set; } = null!;

    public virtual Usuario? Usuario { get; set; }
}
