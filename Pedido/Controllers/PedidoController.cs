using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PedidoAPI.Data;
using PedidoAPI.Model;
using PedidoAPI.Services;
using PedidoAPI.Util;

namespace PedidoAPI.Controllers
{
    [ApiController]
    [Route("api/pedido")]
    public class PedidoController : ControllerBase
    {

        private readonly ILogger<PedidoController> _logger;
        IService<Pedido> _service;

        public PedidoController(ILogger<PedidoController> logger, IService<Pedido> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(Pedido pedido)
        {
            try
            {
                var result = _service.Create(pedido);
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
        public IActionResult Get([FromQuery] int mesa)
        {
            try
            {
                Result<Pedido> result = _service.Read(new Pedido() { MesaId = mesa });
                return CreatedAtAction("Get", result.Entities[0]);
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id_pedido}")]
        public IActionResult Get([FromRoute] Guid id_pedido)
        {
            try
            {
                Result<Pedido> result = _service.Read(new Pedido() { Id = id_pedido });
                return CreatedAtAction("Get", result.Entities);
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpPatch]
        public IActionResult Patch(Pedido pedido)
        {
            try
            {

                var result = _service.Update(pedido);
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
