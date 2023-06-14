using System;
using System.Collections.Generic;

namespace Meu_Treino.Models.Dtos;

public partial class Progresso
{
    public int? UsuarioId { get; set; }

    public decimal? Peso { get; set; }

    public string? MedidasCorporais { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
