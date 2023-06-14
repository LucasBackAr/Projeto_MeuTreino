using System;
using System.Collections.Generic;

namespace Meu_Treino.Models.Dtos;

public partial class ExerciciosPlano
{
    public int? PlanoId { get; set; }

    public int? ExercicioId { get; set; }

    public int Repeticoes { get; set; }

    public int Series { get; set; }

    public virtual Exercicio? Exercicio { get; set; }

    public virtual PlanosTreino? Plano { get; set; }
}
