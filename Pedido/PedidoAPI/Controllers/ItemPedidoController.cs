using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PedidoAPI.Model;

namespace PedidoAPI.Controllers
{
    [ApiController]
    [Route("api/pedido/{id_pedido}/item_pedido")]
    public class ItemPedidoController : ControllerBase
    {

        private readonly ILogger<ItemPedidoController> _logger;

        public ItemPedidoController(ILogger<ItemPedidoController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post(ItemPedido itemPedido)
        {
            try
            {
                //var result = facade.Create(cardapio);
                //if (result.Success)
                //return CreatedAtAction("CreateCardapio", new { Id = result.Entities[0].Id });
                //return BadRequest(result.Messages);

                return CreatedAtAction("Post", new { Id = 0 });
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id_item_pedido}")]
        public IActionResult Get([FromRoute] int id_item_pedido)
        {
            try
            {
                // var result = facade.Read(new Cardapio() { Id = idCardapio });
                // if (result != null && result.Entities != null && result.Entities.Count > 0)
                //     return CreatedAtAction("ReadCardapio", result.Entities[0]);
                // else
                //     return CreatedAtAction("ReadCardapio", new { });

                return CreatedAtAction("Get", new List<ItemPedido>() { new ItemPedido() { } });
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // var result = facade.Read(new Cardapio() { Id = idCardapio });
                // if (result != null && result.Entities != null && result.Entities.Count > 0)
                //     return CreatedAtAction("ReadCardapio", result.Entities[0]);
                // else
                //     return CreatedAtAction("ReadCardapio", new { });
                return CreatedAtAction("Get", new List<ItemPedido>() { new ItemPedido() { } });
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpPatch]
        public IActionResult Patch(ItemPedido itemPedido)
        {
            try
            {
                // var result = facade.Update(cardapio);
                // if (result.Success)
                //     return CreatedAtAction("UpdateCardapio", result.Entities[0]);

                // // return BadRequest();
                var item = new ItemPedido() {};
                return CreatedAtAction("Patch", item);
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }
    }
}
