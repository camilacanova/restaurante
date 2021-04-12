using CardapioService.Model;
using CardapioService.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Data
{
    public class ItemCardapioRepository : AbstractRepository<ItemCardapio>
    {
        public ItemCardapioRepository(CardapioServiceContext context) : base(context)
        {

        }

        public override Result<ItemCardapio> ReadAll(ItemCardapio cardapio)
        {
            List<ItemCardapio> cardapios = context.Set<ItemCardapio>().
                Where(x => x.CardapioId == cardapio.CardapioId).
                OrderBy(x => x.Id).ToList();
            Result<ItemCardapio> result = new Result<ItemCardapio>(true, cardapios);
            return result;
        }

    }
}
