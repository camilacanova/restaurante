using CardapioService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Strategies
{
    public class CreateItemCardapio : IStrategy<ItemCardapio>
    {
        public bool Execute(ItemCardapio entity)
        {
            if (string.IsNullOrEmpty(entity.NomeItem) || entity.CardapioId <= 0)
                return false;
            return true;
        }
    }
}
