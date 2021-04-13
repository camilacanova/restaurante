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
    [Route("Pedido")]
    public class PedidoController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string HOST;

        public PedidoController(ILogger<HomeController> logger)
        {
            _logger = logger;
            HOST = Environment.GetEnvironmentVariable("SERVICE_HOST");
        }

        [Route("Pedido")]
        public IActionResult Pedido()
        {
            Carrinho carrinho;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Carrinho")))
            {
                var value = HttpContext.Session.GetString("Carrinho");
                carrinho = JsonConvert.DeserializeObject<Carrinho>(value);
            }
            else
            {
                //Teste
                carrinho = new Carrinho();
                carrinho.Itens = new List<ItemCarrinho>();
                carrinho.Itens.Add(new ItemCarrinho { CardapioId = 1, ItemId = 1, Quantidade = 1, Valor = 10 });
            }

            Pedido pedido = new Pedido();
            pedido.Itens = new List<ItemPedido>();
            pedido.Itens.Add(new ItemPedido() { ProdutoId = 1, Quantidade = 1 });

            //HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //System.Net.Http.HttpResponseMessage response = client.GetAsync(string.Format("https://{0}/api/cardapio", HOST)).Result;
            //List<Cardapio> cardapios = new List<Cardapio>();
            ////se retornar com sucesso busca os dados 
            //if (response.IsSuccessStatusCode)
            //{

            //    //Pegando os dados do Rest e armazenando na variável usuários 
            //    cardapios = response.Content.ReadAsAsync<List<Cardapio>>().Result;
            //}
            //string imgPath = System.IO.Path.GetFullPath("C:/DEV/ClienteUI/wwwroot/lib/ImageNotFound.png");
            //byte[] img = System.IO.File.ReadAllBytes(imgPath);
            //string imagem = Convert.ToBase64String(img);

            //foreach (var card in cardapios)
            //{
            //    if (string.IsNullOrEmpty(card.Imagem))
            //    {
            //        card.Imagem = imagem;
            //    }
            //}

            return View(pedido);
        }
    }
}
