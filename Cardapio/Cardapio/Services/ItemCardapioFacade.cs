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
    public class ItemCardapioFacade : DefaultFacade<ItemCardapio>
    {
        public ItemCardapioFacade(CardapioServiceContext context) : base(new ItemCardapioBuilder(context))
        {
        }

        public override Result<ItemCardapio> Update(ItemCardapio entity)
        {
            var result = factoryResponse.Repository.Read(entity);
            ItemCardapio itemUpdate = result.Entities[0];

            if (itemUpdate != null)
            {
                itemUpdate.NomeItem = entity.NomeItem;
                itemUpdate.Valor = entity.Valor;
                itemUpdate.Observacao = entity.Observacao;

                return base.Update(itemUpdate);
            }
            return base.Create(entity);

        }
    }
}
