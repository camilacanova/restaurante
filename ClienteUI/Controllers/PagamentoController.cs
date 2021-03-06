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
    [Route("Pagamento")]
    public class PagamentoController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string hostPedido;

        public PagamentoController(ILogger<HomeController> logger)
        {
            _logger = logger;
            hostPedido = Environment.GetEnvironmentVariable("SERVICE_PEDIDO");
        }

        [Route("ListaPagamento")]
        public IActionResult ListaPagamento()
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

            decimal valorTotal = 0;

            foreach (ItemPedido item in pedido.Itens)
            {
                valorTotal += item.Produto.Valor * item.Quantidade;
            }

            HttpContext.Session.SetString("Pedido", pedido.Id.ToString());
            pedido.ValorTotal = valorTotal;

            return View(pedido);
        }

        [Route("PagarAgora")]
        public IActionResult PagarAgora(decimal valor)
        {
            Guid id;
            Guid.TryParse(HttpContext.Session.GetString("Pedido"), out id);
            Pagamento pag = new Pagamento() { PedidoId = id, Valor = valor };

            return View(pag);
        }

        [Route("Pagar")]
        public IActionResult Pagar(decimal valor, string pedidoId)
        {
            Guid id;
            Guid.TryParse(pedidoId, out id);
            Pagamento pag = new Pagamento() { PedidoId = id, Valor = valor, Parcelas = 1, TipoPagamentoId = (int)EnumTipoPagamento.Cartao };

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            System.Net.Http.HttpResponseMessage response = client.PostAsJsonAsync<Pagamento>(string.Format("https://{0}/api/pagamento", hostPedido), pag).Result;

            //se retornar com sucesso busca os dados 
            if (response.IsSuccessStatusCode)
            {
                HttpContext.Session.Remove("Pedido");
                return View("QRCODE");
            }


            return View("QRCODE");
        }
    }
}
