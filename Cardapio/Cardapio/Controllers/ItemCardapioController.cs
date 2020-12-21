using System;
using System.Collections.Generic;
using System.Linq;
using CardapioService.Data;
using CardapioService.Model;
using CardapioService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CardapioService.Controllers
{
    [Route("api/cardapio/{id_cardapio}/item_cardapio")]
    [ApiController]
    public class ItemCardapioController : ControllerBase
    {
        private readonly CardapioServiceContext context;
        private readonly ILogger<ItemCardapioController> _logger;
        private ItemCardapioFacade facade;

        public ItemCardapioController(CardapioServiceContext context, ILogger<ItemCardapioController> logger)
        {
            facade = new ItemCardapioFacade(context);
            this.context = context;
            _logger = logger;
        }


        [HttpPost]
        public IActionResult CreateItemCardapio([FromRoute]int id_cardapio, ItemCardapio itemCardapio)
        {
            try
            {
                var result = facade.Create(itemCardapio);
                if (result.Success)
                    return CreatedAtAction("CreateItemCardapio", new { Id = result.Entities[0].Id });

                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{idItemCardapio}")]
        public IActionResult ReadItemCardapio([FromRoute] int idItemCardapio)
        {
            try
            {
                var result = facade.Read(new ItemCardapio() { Id = idItemCardapio });

                if (result != null && result.Entities != null && result.Entities.Count > 0)
                    return CreatedAtAction("ReadItemCardapio", result.Entities[0]);

                return CreatedAtAction("ReadItemCardapio", new { });
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult ReadAllItemCardapio()
        {
            try
            {
                var result = facade.ReadAll(new ItemCardapio());
                return CreatedAtAction("ReadAllItemCardapio", new { result.Entities });
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateItemCardapio(ItemCardapio itemCardapio)
        {
            try
            {
                var result = facade.Update(itemCardapio);
                if (result.Success)
                    return CreatedAtAction("UpdateItemCardapio", result.Entities[0]);

                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult DeleteItemCardapio(int idItemCardapio)
        {
            try
            {
                var result = facade.Delete(new ItemCardapio() { Id = idItemCardapio });
                if (result.Success)
                    return CreatedAtAction("DeleteItemCardapio", "Item Cardápio removido");
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