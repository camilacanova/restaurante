using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CardapioUI.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using System.Text;

namespace CardapioUI.Controllers
{
    [Route("Cozinha")]
    public class CozinhaController : Controller
    {
        private readonly ILogger<CozinhaController> _logger;
        private string hostPedido;

        public CozinhaController(ILogger<CozinhaController> logger)
        {
            hostPedido = Environment.GetEnvironmentVariable("SERVICE_PEDIDO");
            _logger = logger;
        }

        [Route("VerPedidos")]
        public IActionResult VerPedidos()
        {

            //Retornar todos os pedidos
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpResponseMessage response = client.GetAsync(string.Format("https://{0}/api/pedido", hostPedido)).Result;
            List<Pedido> pedido = new List<Pedido>();
            //se retornar com sucesso busca os dados 
            if (response.IsSuccessStatusCode)
            {
                pedido = response.Content.ReadAsAsync<List<Pedido>>().Result;
            }

            return View(pedido);
        }

        [Route("Evoluir")]
        public IActionResult Evoluir(Guid idPedido, Guid idItem)
        {

            //Retornar o pedido
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpResponseMessage response = client.GetAsync(string.Format("https://{0}/api/pedido/{1}", hostPedido, idPedido)).Result;
            Pedido pedido = new Pedido();
            //se retornar com sucesso busca os dados 
            if (response.IsSuccessStatusCode)
            {
                pedido = response.Content.ReadAsAsync<Pedido>().Result;
            }

            ItemPedido item = pedido.Itens.FindLast(x => x.Id == idItem);
            item.StatusItemId++;
            item.StatusItem.Id++;
            item.StatusItem = null;

            //Atualiza o pedido
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var jsonRequest = JsonConvert.SerializeObject(pedido);

            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

            response = client.PatchAsync(string.Format("https://{0}/api/pedido", hostPedido), content).Result;




            return RedirectToAction("VerPedidos");
        }

    }
}
