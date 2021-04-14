using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PedidoAPI.Data;
using PedidoAPI.Model;
using PedidoAPI.Model.Enums;
using PedidoAPI.Services;
using PedidoAPI.Util;

namespace PedidoAPI.Controllers
{
    [ApiController]
    [Route("api/mesa")]
    public class MesaController : ControllerBase
    {

        private readonly ILogger<MesaController> _logger;
        ITypeService<Mesa> _service;

        public MesaController(ILogger<MesaController> logger, ITypeService<Mesa> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(Mesa Mesa)
        {
            try
            {
                var result = _service.Create(Mesa);
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
        [Route("{id_mesa}")]
        public IActionResult Get([FromRoute] int id_mesa)
        {
            try
            {
                Result<Mesa> result = _service.Read(new Mesa() { Id = id_mesa });
                return CreatedAtAction("Get", result.Entities);
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpPatch]
        public IActionResult Patch(Mesa Mesa)
        {
            try
            {

                var result = _service.Update(Mesa);
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
