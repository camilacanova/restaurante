using CardapioService.Data;
using CardapioService.Model;
using CardapioService.Structures;
using CardapioService.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Services
{
    public class CardapioFacade : DefaultFacade<Cardapio>
    {
        public CardapioFacade(CardapioServiceContext context) : base(new CardapioFactory(context))
        {
        }

        public override Result<Cardapio> Update(Cardapio entity)
        {
            var result = factoryResponse.Repository.Read(entity);
            Cardapio cardapioUpdate = result.Entities[0];

            if (cardapioUpdate != null)
            {
                cardapioUpdate.Nome = entity.Nome;
                cardapioUpdate.Observacao = entity.Observacao;

                return base.Update(cardapioUpdate);
            }
            return base.Create(entity);

        }
    }
}
