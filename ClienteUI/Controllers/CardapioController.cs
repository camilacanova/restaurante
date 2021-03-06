using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using ClienteUI.Models;

namespace ClienteUI.Controllers
{
    [Route("Cardapio")]
    public class CardapioController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string HOST;

        public CardapioController(ILogger<HomeController> logger)
        {
            _logger = logger;
            HOST = Environment.GetEnvironmentVariable("SERVICE_CARDAPIO");
        }

        [Route("ListaCardapios")]
        public IActionResult ListaCardapios()
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpResponseMessage response = client.GetAsync(string.Format("https://{0}/api/cardapio", HOST)).Result;
            List<Cardapio> cardapios = new List<Cardapio>();
            //se retornar com sucesso busca os dados 
            if (response.IsSuccessStatusCode)
            {

                //Pegando os dados do Rest e armazenando na variável usuários 
                cardapios = response.Content.ReadAsAsync<List<Cardapio>>().Result;
            }
            string imgPath = System.IO.Path.GetFullPath("C:/DEV/ClienteUI/wwwroot/lib/back.jpg");
            byte[] img = System.IO.File.ReadAllBytes(imgPath);
            string imagem = Convert.ToBase64String(img);

            foreach (var card in cardapios)
            {
                if (string.IsNullOrEmpty(card.Imagem))
                {
                    card.Imagem = imagem;
                }
            }

            return View(cardapios);
        }
    }
}
