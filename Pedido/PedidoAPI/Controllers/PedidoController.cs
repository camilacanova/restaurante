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
        private PedidoContext context;
        IService<Pedido> service;

        public PedidoController(ILogger<PedidoController> logger, PedidoContext context, IService<Pedido> service)
        {
            _logger = logger;
            this.service = service;
            this.context = context;
        }

        [HttpPost]
        public IActionResult Post(Pedido pedido)
        {
            try
            {
                //var result = facade.Create(cardapio);
                //if (result.Success)
                //return CreatedAtAction("CreateCardapio", new { Id = result.Entities[0].Id });
                //return BadRequest(result.Messages);
                
                Result<Pedido> result = service.Create(pedido);
                return CreatedAtAction("Post", new { Id = result.Entities[0].Id });
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
                // var result = facade.Read(new Cardapio() { Id = idCardapio });
                // if (result != null && result.Entities != null && result.Entities.Count > 0)
                //     return CreatedAtAction("ReadCardapio", result.Entities[0]);
                // else
                //     return CreatedAtAction("ReadCardapio", new { });

                Result<Pedido> result = service.Create(new Pedido() { MesaId = mesa });
                return CreatedAtAction("Get", result.Entities);
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id_pedido}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            try
            {
                // var result = facade.Read(new Cardapio() { Id = idCardapio });
                // if (result != null && result.Entities != null && result.Entities.Count > 0)
                //     return CreatedAtAction("ReadCardapio", result.Entities[0]);
                // else
                //     return CreatedAtAction("ReadCardapio", new { });
                return CreatedAtAction("Get", new List<Pedido>() { new Pedido() { } });
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

                // var result = facade.Update(cardapio);
                // if (result.Success)
                //     return CreatedAtAction("UpdateCardapio", result.Entities[0]);

                // return BadRequest();
                return CreatedAtAction("Patch", new Pedido());
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }
    }
}
