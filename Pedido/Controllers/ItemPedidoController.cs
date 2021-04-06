using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PedidoAPI.Model;
using PedidoAPI.Services;
using PedidoAPI.Util;

namespace PedidoAPI.Controllers
{
    [ApiController]
    [Route("api/pedido/{id_pedido}/item_pedido")]
    public class ItemPedidoController : ControllerBase
    {

        private readonly ILogger<ItemPedidoController> _logger;
        IService<ItemPedido> _service;


        public ItemPedidoController(ILogger<ItemPedidoController> logger, IService<ItemPedido> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(ItemPedido itemPedido)
        {
            try
            {
                var result = _service.Create(itemPedido);
                if (result.Success)
                    return CreatedAtAction("Post", new { Id = result.Entities[0].Id });
                return BadRequest(result.Messages);
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id_item_pedido}")]
        public IActionResult Get([FromRoute] Guid id_item_pedido)
        {
            try
            {
                Result<ItemPedido> result = _service.Read(new ItemPedido() { Id = id_item_pedido });
                return CreatedAtAction("Get", result.Entities);
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
                Result<ItemPedido> result = _service.Read(new ItemPedido());
                return CreatedAtAction("Get", result.Entities);
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
                var result = _service.Update(itemPedido);
                if (result.Success)
                    return CreatedAtAction("Patch", result.Entities[0]);

                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }
    }
}
