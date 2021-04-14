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
                var result = _service.Create(Pagamento);
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
        [Route("{id}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            try
            {
                Result<Pagamento> result = _service.Read(new Pagamento() { Id = id });
                return CreatedAtAction("Get", result.Entities[0]);
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }


    }
}
