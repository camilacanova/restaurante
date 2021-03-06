using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using ClienteUI.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ClienteUI.Controllers
{
    [Route("ItemCardapio")]
    public class ItemCardapioController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string HOST;

        public ItemCardapioController(ILogger<HomeController> logger)
        {
            _logger = logger;
            HOST = Environment.GetEnvironmentVariable("SERVICE_CARDAPIO");
        }

        [Route("ListaItensCardapio/{idCardapio}")]
        public IActionResult ListaItensCardapio([FromRoute] int idCardapio)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpResponseMessage response = client.GetAsync(string.Format("https://{0}/api/cardapio/{1}/item_cardapio", HOST, idCardapio)).Result;

            List<ItemCardapio> itensCardapio = new List<ItemCardapio>();
            //se retornar com sucesso busca os dados 
            if (response.IsSuccessStatusCode)
            {

                //Pegando os dados do Rest e armazenando na variável usuários 
                itensCardapio = response.Content.ReadAsAsync<List<ItemCardapio>>().Result;
            }


            return View(itensCardapio);
        }

        [Route("Carrinho")]
        public IActionResult Carrinho([FromQuery] int idCardapio, [FromQuery] int idItem, [FromQuery] string nome, [FromQuery] int quantidade, decimal valor)
        {

            Carrinho carrinho;
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Carrinho")))
            {
                carrinho = new Carrinho();
                carrinho.Itens = new List<ItemCarrinho>();
                if (idCardapio != 0)
                    carrinho.Itens.Add(new ItemCarrinho { CardapioId = idCardapio, ItemId = idItem, NomeItem = nome, Quantidade = 1, Valor = valor });

                HttpContext.Session.SetString("Carrinho", JsonConvert.SerializeObject(carrinho));
            }
            else
            {
                var value = HttpContext.Session.GetString("Carrinho");
                carrinho = JsonConvert.DeserializeObject<Carrinho>(value);
                if (idCardapio != 0)
                    carrinho.Itens.Add(new ItemCarrinho { CardapioId = idCardapio, ItemId = idItem, NomeItem = nome, Quantidade = 1, Valor = valor });

                HttpContext.Session.SetString("Carrinho", JsonConvert.SerializeObject(carrinho));
            }

            return View(carrinho);
        }
    }
}
