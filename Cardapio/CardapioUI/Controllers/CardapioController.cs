﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CardapioUI.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace CardapioUI.Controllers
{
    public class CardapioController : Controller
    {
        private readonly ILogger<CardapioController> _logger;
        private string HOST;

        public CardapioController(ILogger<CardapioController> logger)
        {
            HOST = Environment.GetEnvironmentVariable("SERVICE_CARDAPIO");
            _logger = logger;
        }

        public IActionResult VerCardapio()
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
                    HttpResponseMessage response = client.PostAsJsonAsync<Cardapio>(string.Format("https://{0}/api/cardapio", HOST), cardapio).Result;
                    return RedirectToAction("VerCardapio");
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

            System.Net.Http.HttpResponseMessage response = client.GetAsync(string.Format("https://{0}/api/cardapio/{1}", HOST, id)).Result;
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

            HttpResponseMessage response = client.DeleteAsync(string.Format("https://{0}/api/cardapio?idCardapio={1}", HOST, id)).Result;


            return RedirectToAction("VerCardapio", "Cardapio");
        }

        public IActionResult EditarCardapio(int id, Cardapio cardapio)
        {

            if (cardapio == null || string.IsNullOrEmpty(cardapio.Nome))
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.Http.HttpResponseMessage response = client.GetAsync(string.Format("https://{0}/api/cardapio/{1}", HOST, id)).Result;
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
                    HttpResponseMessage response = client.PutAsJsonAsync(string.Format("https://{0}/api/cardapio", HOST), cardapio).Result;
                    return View("DetalhesCardapio", cardapio);
                }
            }
            return View("DetalhesCardapio", cardapio);
        }

    }
}
