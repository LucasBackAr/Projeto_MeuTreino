﻿using Meu_Treino.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Meu_Treino.Controllers
{
    [PaginaLogado]
    public class ExercicioController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }
    }
}
