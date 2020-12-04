using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CardapioUI.Models;
using System.Net.Http;

namespace CardapioUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpResponseMessage response = client.GetAsync("https://localhost:44308/cardapio/readAll").Result;
            List<Cardapio> cardapios = new List<Cardapio>();
            //se retornar com sucesso busca os dados 
            if (response.IsSuccessStatusCode)
            {

                //Pegando os dados do Rest e armazenando na variável usuários 
                cardapios = response.Content.ReadAsAsync<List<Cardapio>>().Result;
            }

            return View("ListaCardapio", cardapios);
        }

        public IActionResult CriarCardapio(Cardapio cardapio)
        {

            return View();
        }
    }
}
