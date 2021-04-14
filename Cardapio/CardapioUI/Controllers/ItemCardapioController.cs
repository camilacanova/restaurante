using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CardapioUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CardapioUI.Controllers
{
    public class ItemCardapioController : Controller
    {
        private readonly ILogger<ItemCardapioController> _logger;
        private string HOST;

        public ItemCardapioController(ILogger<ItemCardapioController> logger)
        {
            HOST = Environment.GetEnvironmentVariable("SERVICE_CARDAPIO");
            _logger = logger;
        }

        public IActionResult CriarItem(int IdCardapio, ItemCardapio itemCardapio)
        {
            try
            {
                if (ModelState.IsValid && !string.IsNullOrEmpty(itemCardapio.NomeItem))
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PostAsJsonAsync<ItemCardapio>(string.Format("https://{1}/api/cardapio/{0}/item_cardapio", itemCardapio.CardapioId, HOST), itemCardapio).Result;
                    return RedirectToAction("DetalhesCardapio", "Cardapio", new { id = itemCardapio.CardapioId });
                }
                else
                {
                    itemCardapio = new ItemCardapio();
                    itemCardapio.CardapioId = IdCardapio;
                }

                return View(itemCardapio);
            }
            catch
            {
                return View(itemCardapio);
            }
        }

        public IActionResult EditarItemCardapio(int id, int IdCardapio, ItemCardapio itemCardapio)
        {

            if (itemCardapio == null || string.IsNullOrEmpty(itemCardapio.NomeItem))
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.Http.HttpResponseMessage response = client.GetAsync(string.Format("https://{2}/api/cardapio/{0}/item_cardapio/{1}", IdCardapio, id, HOST)).Result;
                //se retornar com sucesso busca os dados 
                if (response.IsSuccessStatusCode)
                {
                    //Pegando os dados do Rest e armazenando na variável usuários 
                    itemCardapio = response.Content.ReadAsAsync<ItemCardapio>().Result;
                }
                return View("EditarItemCardapio", itemCardapio);
            }
            else
            {
                if (ModelState.IsValid && !string.IsNullOrEmpty(itemCardapio.NomeItem))
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PutAsJsonAsync(string.Format("https://{1}/api/cardapio/{0}/item_cardapio", itemCardapio.CardapioId, HOST), itemCardapio).Result;
                    return RedirectToAction("DetalhesCardapio", "Cardapio", new { id = itemCardapio.CardapioId });
                }
            }
            return RedirectToAction("DetalhesCardapio", "Cardapio", new { id = itemCardapio.CardapioId });
        }

        public IActionResult ExcluirItemCardapio(int id, int IdCardapio)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.DeleteAsync(string.Format("https://{2}/api/cardapio/{0}/item_cardapio?idItemCardapio={1}", IdCardapio, id, HOST)).Result;


            return RedirectToAction("VerCardapio", "Cardapio");
        }
    }
}