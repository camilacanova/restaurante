using CardapioService.Model;
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
    }
}
