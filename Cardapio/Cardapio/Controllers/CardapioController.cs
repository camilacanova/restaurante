using CardapioService.Data;
using CardapioService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardapioService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardapioController : ControllerBase
    {

        private readonly CardapioServiceContext context;
        private readonly ILogger<CardapioController> _logger;

        public CardapioController(CardapioServiceContext context, ILogger<CardapioController> logger)
        {
            this.context = context;
            _logger = logger;
        }


        [HttpPost]
        [Route("create")]
        public IActionResult CreateCardapio(Cardapio cardapio)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    context.Add(cardapio);
                    context.SaveChanges();


                    return CreatedAtAction("CreateCardapio", new { Id = cardapio.Id });
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
        public IActionResult ReadCardapio(int idCardapio)
        {
            try
            {
                Cardapio cardapio = context.Set<Cardapio>().SingleOrDefault(c => c.Id == idCardapio);
                return CreatedAtAction("ReadCardapio", new { cardapio });
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("readAll")]
        public IActionResult ReadAllCardapio()
        {
            try
            {
                List<Cardapio> cardapios = context.Set<Cardapio>().OrderBy(x => x.Id).ToList();
                return CreatedAtAction("ReadAllCardapio", new { cardapios });
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpPatch]
        [Route("update")]
        public IActionResult UpdateCardapio(Cardapio cardapio)
        {
            try
            {
                if (ModelState.IsValid && cardapio.Id != 0)
                {
                    Cardapio cardapioUpdate = context.Set<Cardapio>().SingleOrDefault(c => c.Id == cardapio.Id);

                    if (cardapioUpdate != null)
                    {
                        cardapioUpdate.Nome = cardapio.Nome;
                        cardapioUpdate.Observacao = cardapio.Observacao;

                        context.SaveChanges();

                        return CreatedAtAction("UpdateCardapio", cardapioUpdate);
                    }
                    else
                    {
                        context.Add(cardapio);
                        context.SaveChanges();


                        return CreatedAtAction("UpdateCardapio", new { Id = cardapio.Id });
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
        public IActionResult DeleteCardapio(int idCardapio)
        {
            try
            {
                Cardapio cardapioDelete = context.Set<Cardapio>().SingleOrDefault(c => c.Id == idCardapio);
                context.Remove(cardapioDelete);

                context.SaveChanges();
                return CreatedAtAction("DeleteCardapio", "Cardápio removido");

            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }
    }
}
