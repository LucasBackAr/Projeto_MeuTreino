using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meu_Treino.Models.Dtos;

public partial class PlanosTreino
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    [Required(ErrorMessage = "{0} é Obrigatório")]
    [StringLength(50, ErrorMessage = "Use menos caracteres")]
    public string NomePlano { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public string Objetivo { get; set; } = null!;
    public string Identificadores { get; set; } = null!;
    public string Datas { get; set; } = null!;

    public virtual Usuario? Usuario { get; set; }
}
