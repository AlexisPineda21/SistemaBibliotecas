﻿using Microsoft.AspNetCore.Mvc;

namespace SistemaBibliotecas.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
