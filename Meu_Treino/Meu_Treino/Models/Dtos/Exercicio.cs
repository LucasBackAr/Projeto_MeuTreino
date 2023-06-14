using System;
using System.Collections.Generic;

namespace Meu_Treino.Models.Dtos;

public partial class Exercicio
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public string GrupoMuscular { get; set; } = null!;

    public string Instrucoes { get; set; } = null!;

    public string NivelDificuldade { get; set; } = null!;

    public string? Equipamentos { get; set; }
}
