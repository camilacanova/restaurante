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
    [Route("cardapio/{id_cardapio}/item_cardapio")]
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
        [Route("create")]
        public IActionResult CreateItemCardapio(ItemCardapio itemCardapio)
        {
            try
            {
                var result = facade.Create(itemCardapio);
                if (result.Success)
                    return CreatedAtAction("CreateCardapio", new { Id = result.Entities[0].Id });

                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("read")]
        public IActionResult ReadItemCardapio(int idItemCardapio)
        {
            try
            {
                var result = facade.Read(new ItemCardapio() { Id = idItemCardapio });
                return CreatedAtAction("ReadCardapio", new { result.Entities });
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("readAll")]
        public IActionResult ReadAllItemCardapio()
        {
            try
            {
                var result = facade.ReadAll(new ItemCardapio());
                return CreatedAtAction("ReadAllCardapio", new { result.Entities });
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpPatch]
        [Route("update")]
        public IActionResult UpdateItemCardapio(ItemCardapio itemCardapio)
        {
            try
            {
                var result = facade.Update(itemCardapio);
                if (result.Success)
                    return CreatedAtAction("UpdateCardapio", result.Entities[0]);

                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("delete")]
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