﻿using Meu_Treino.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Meu_Treino.ViewComponents
{
    public class Menu : ViewComponent
    {   /// <summary>
        /// Cria um Menu para ser usado nas Views 
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if(string.IsNullOrEmpty(sessaoUsuario)) 
            { return View(new Usuario()); }
            
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);

            return View(usuario);
            
        }
    }
}
