using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CardapioUI.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace CardapioUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string HOST;

        public HomeController(ILogger<HomeController> logger)
        {
            HOST = Environment.GetEnvironmentVariable("SERVICE_CARDAPIO");
            _logger = logger;
        }
        public IActionResult Index()
        {
            return RedirectToAction("VerPedidos", "Cozinha");
        }

    }
}
