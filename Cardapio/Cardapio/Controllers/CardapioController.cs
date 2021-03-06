﻿using CardapioService.Data;
using CardapioService.Model;
using CardapioService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardapioService.Controllers
{
    [ApiController]
    [Route("api/cardapio")]
    public class CardapioController : ControllerBase
    {

        private readonly CardapioServiceContext context;
        private readonly ILogger<CardapioController> _logger;
        private CardapioFacade facade;

        public CardapioController(CardapioServiceContext context, ILogger<CardapioController> logger)
        {
            facade = new CardapioFacade(context);
            this.context = context;
            _logger = logger;
        }


        [HttpPost]
        public IActionResult CreateCardapio(Cardapio cardapio)
        {
            try
            {
                var result = facade.Create(cardapio);
                if (result.Success)
                    return CreatedAtAction("CreateCardapio", new { Id = result.Entities[0].Id });

                return BadRequest(result.Messages);
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{idCardapio}")]
        public IActionResult ReadCardapio([FromRoute] int idCardapio)
        {
            try
            {
                var result = facade.Read(new Cardapio() { Id = idCardapio });
                if (result != null && result.Entities != null && result.Entities.Count > 0)
                    return CreatedAtAction("ReadCardapio", result.Entities[0]);
                else
                    return CreatedAtAction("ReadCardapio", new { });
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult ReadAllCardapio()
        {
            try
            {
                var result = facade.ReadAll(new Cardapio());
                return CreatedAtAction("ReadAllCardapio", result.Entities);
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex.Message);
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateCardapio(Cardapio cardapio)
        {
            try
            {

                var result = facade.Update(cardapio);
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
        public IActionResult DeleteCardapio(int idCardapio)
        {
            try
            {
                var result = facade.Delete(new Cardapio() { Id = idCardapio });
                if (result.Success)
                    return CreatedAtAction("DeleteCardapio", "Cardápio removido");

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
