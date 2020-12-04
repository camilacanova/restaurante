using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CardapioUI.Models;
using System.Net.Http;
using System.Threading.Tasks;

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
            try
            {
                if (ModelState.IsValid && !string.IsNullOrEmpty(cardapio.Nome))
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync<Cardapio>("https://localhost:44308/cardapio/create", cardapio).Result;
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        public IActionResult DetalhesCardapio(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpResponseMessage response = client.GetAsync("https://localhost:44308/cardapio/read?idCardapio=" + id).Result;
            Cardapio cardapio = new Cardapio();
            //se retornar com sucesso busca os dados 
            if (response.IsSuccessStatusCode)
            {

                //Pegando os dados do Rest e armazenando na variável usuários 
                cardapio = response.Content.ReadAsAsync<Cardapio>().Result;
            }

            return View("DetalhesCardapio", cardapio);
        }

        public IActionResult ExcluirCardapio(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("https://localhost:44308/cardapio/delete?idCardapio=" + id).Result;


            return RedirectToAction("Index", "Home");
        }

        public IActionResult EditarCardapio(int id, Cardapio cardapio)
        {

            if (cardapio == null || string.IsNullOrEmpty(cardapio.Nome))
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.Http.HttpResponseMessage response = client.GetAsync("https://localhost:44308/cardapio/read?idCardapio=" + id).Result;
                //se retornar com sucesso busca os dados 
                if (response.IsSuccessStatusCode)
                {
                    //Pegando os dados do Rest e armazenando na variável usuários 
                    cardapio = response.Content.ReadAsAsync<Cardapio>().Result;
                }
                return View("EditarCardapio", cardapio);
            }
            else
            {
                if (ModelState.IsValid && !string.IsNullOrEmpty(cardapio.Nome))
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PutAsJsonAsync("https://localhost:44308/cardapio/update", cardapio).Result;
                    return View("DetalhesCardapio", cardapio);
                }
            }
            return View("DetalhesCardapio", cardapio);
        }

    }
}
