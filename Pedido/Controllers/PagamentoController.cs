using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PedidoAPI.Model;
using PedidoAPI.Services;

namespace PedidoAPI.Controllers
{
    [ApiController]
    [Route("api/pagamento")]
    public class PagamentoController : ControllerBase
    {
        private readonly ILogger<PagamentoController> _logger;
        private IService<Pagamento> _service;
        public PagamentoController(ILogger<PagamentoController> logger, IService<Pagamento> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(Pagamento Pagamento)
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
        [Route("{id}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            try
            {
                // var result = facade.Read(new Cardapio() { Id = idCardapio });
                // if (result != null && result.Entities != null && result.Entities.Count > 0)
                //     return CreatedAtAction("ReadCardapio", result.Entities[0]);
                // else
                //     return CreatedAtAction("ReadCardapio", new { });

                return CreatedAtAction("Get", new List<Pagamento>() { new Pagamento() { } });
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }


    }
}
