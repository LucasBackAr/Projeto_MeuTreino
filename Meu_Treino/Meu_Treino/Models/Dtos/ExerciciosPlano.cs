using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meu_Treino.Models.Dtos;

public partial class ExerciciosPlano
{
    [Key]
    public int Id { get; set; }

    public int? PlanoId { get; set; }

    public int? ExercicioId { get; set; }

    public int Repeticoes { get; set; }

    public int Series { get; set; }

    public virtual Exercicio? Exercicio { get; set; }

    public virtual PlanosTreino? Plano { get; set; }

    [NotMapped]
    public int SelectedExerciseId { get; set; }
    [NotMapped]
    public IEnumerable<SelectListItem> Exercicios { get; set; }
    [NotMapped]
    public int SelectedPlanoId { get; set; }
    [NotMapped]
    public IEnumerable<SelectListItem> Planos { get; set; }
    
}
