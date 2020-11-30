using CardapioService.Model;
using CardapioService.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Strategies
{
    public class CreateItemCardapio : IStrategy<ItemCardapio>
    {
        public Result<ItemCardapio> Execute(ItemCardapio entity)
        {

            if (string.IsNullOrEmpty(entity.NomeItem) || entity.CardapioId <= 0)
                return new Result<ItemCardapio>() { Success = false, Messages = new List<string> { "Nome e id do Cardápio são obrigatórios" } };
            return new Result<ItemCardapio>() { Success = true };
        }
    }
}
