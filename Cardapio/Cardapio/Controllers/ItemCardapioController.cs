using System;
using System.Collections.Generic;
using System.Linq;
using CardapioService.Data;
using CardapioService.Model;
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

        public ItemCardapioController(CardapioServiceContext context, ILogger<ItemCardapioController> logger)
        {
            this.context = context;
            _logger = logger;
        }


        [HttpPost]
        [Route("create")]
        public IActionResult CreateItemCardapio(ItemCardapio itemCardapio)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    context.Add(itemCardapio);
                    context.SaveChanges();


                    return CreatedAtAction("CreateItemCardapio", new { Id = itemCardapio.Id });
                }
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
                ItemCardapio itemCardapio = context.Set<ItemCardapio>().SingleOrDefault(c => c.Id == idItemCardapio);
                return CreatedAtAction("ReadItemCardapio", new { itemCardapio });
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
                List<ItemCardapio> itensCardapio = context.Set<ItemCardapio>().OrderBy(x => x.Id).ToList();
                return CreatedAtAction("ReadAllItemCardapio", new { itensCardapio });
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
                if (ModelState.IsValid && itemCardapio.Id != 0)
                {
                    ItemCardapio itemCardapioUpdate = context.Set<ItemCardapio>().SingleOrDefault(c => c.Id == itemCardapio.Id);

                    if (itemCardapioUpdate != null)
                    {
                        itemCardapioUpdate.NomeItem = itemCardapio.NomeItem;
                        itemCardapioUpdate.AdicionaisItem = itemCardapio.AdicionaisItem;
                        itemCardapioUpdate.CategoriaItem = itemCardapio.CategoriaItem;
                        itemCardapioUpdate.Observacao = itemCardapio.Observacao;

                        context.SaveChanges();

                        return CreatedAtAction("UpdateItemCardapio", itemCardapioUpdate);
                    }
                    else
                    {
                        context.Add(itemCardapio);
                        context.SaveChanges();


                        return CreatedAtAction("UpdateItemCardapio", new { Id = itemCardapio.Id });
                    }
                }

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
                ItemCardapio itemCardapioDelete = context.Set<ItemCardapio>().SingleOrDefault(c => c.Id == idItemCardapio);
                context.Remove(itemCardapioDelete);

                context.SaveChanges();
                return CreatedAtAction("DeleteItemCardapio", "Item Cardápio removido");

            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }
    }
}