using System;
using System.Collections.Generic;

namespace Meu_Treino.Models.Dtos;

public partial class Perfi
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public string NivelCondicionamento { get; set; } = null!;

    public string Objetivos { get; set; } = null!;

    public string? RestricoesMedicas { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
