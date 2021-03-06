using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using ClienteUI.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ClienteUI.Models.Enums;

namespace ClienteUI.Controllers
{
    [Route("Pedido")]
    public class PedidoController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string hostPedido;

        public PedidoController(ILogger<HomeController> logger)
        {
            _logger = logger;
            hostPedido = Environment.GetEnvironmentVariable("SERVICE_PEDIDO");
        }

        [Route("IncluiPedido")]
        public IActionResult IncluiPedido()
        {
            Carrinho carrinho = new Carrinho();
            HttpClient client;
            HttpResponseMessage response = new HttpResponseMessage();
            IncluiPedidoViewModel pedido = new IncluiPedidoViewModel();
            pedido.Itens = new List<IncluiItemPedidoViewModel>();
            BaseEntity pedidoIncluido;

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Carrinho")))
            {
                var value = HttpContext.Session.GetString("Carrinho");
                carrinho = JsonConvert.DeserializeObject<Carrinho>(value);

                client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                if (string.IsNullOrEmpty(HttpContext.Session.GetString("Pedido")))
                {
                    foreach (ItemCarrinho item in carrinho.Itens)
                    {
                        pedido.Itens.Add(new IncluiItemPedidoViewModel() { CardapioId = item.CardapioId, ProdutoId = item.ItemId, Quantidade = item.Quantidade, StatusItemId = (int)EnumStatusPedido.Aberto });
                        pedido.MesaId = 1;
                        pedido.StatusPedidoId = (int)EnumStatusPedido.Aberto;
                    }

                    //Fazer novo Pedido
                    response = client.PostAsJsonAsync<IncluiPedidoViewModel>(string.Format("https://{0}/api/pedido", hostPedido), pedido).Result;
                    pedidoIncluido = response.Content.ReadAsAsync<BaseEntity>().Result;

                    HttpContext.Session.SetString("Pedido", pedidoIncluido.Id.ToString());
                }
                else
                {
                    string idPedido = HttpContext.Session.GetString("Pedido");
                    foreach (ItemCarrinho item in carrinho.Itens)
                    {
                        IncluiItemPedidoUnicoViewModel itemPedido = new IncluiItemPedidoUnicoViewModel() { pedidoId = idPedido, CardapioId = item.CardapioId, ProdutoId = item.ItemId, Quantidade = item.Quantidade, StatusItemId = (int)EnumStatusPedido.Aberto };
                        //Add iten ao pedido
                        response = client.PostAsJsonAsync<IncluiItemPedidoUnicoViewModel>(string.Format("https://{0}/api/pedido/{1}/item_pedido", hostPedido, idPedido), itemPedido).Result;
                    }
                }

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    //Zerar carrinho
                    HttpContext.Session.Remove("Carrinho");
                    return RedirectToAction("MeusPedidos", "Pedido");
                }
            }

            return RedirectToAction("Carrinho", "ItemCardapio");
        }

        [Route("MeusPedidos")]
        public IActionResult MeusPedidos()
        {
            //Retornar todos os pedidos
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpResponseMessage response = client.GetAsync(string.Format("https://{0}/api/pedido?mesa=1", hostPedido)).Result;
            Pedido pedido = new Pedido();
            //se retornar com sucesso busca os dados 
            if (response.IsSuccessStatusCode)
            {
                pedido = response.Content.ReadAsAsync<Pedido>().Result;
            }

            return View(pedido);
        }
    }
}
