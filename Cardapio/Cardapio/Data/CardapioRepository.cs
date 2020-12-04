using CardapioService.Model;
using CardapioService.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Data
{
    public class CardapioRepository : AbstractRepository<Cardapio>
    {
        public CardapioRepository(CardapioServiceContext context) : base(context)
        {
        }

        public override Result<Cardapio> ReadAll(Cardapio cardapio)
        {
            List<Cardapio> cardapios = context.Set<Cardapio>().
                Include(x => x.ItensCardapio).
                OrderBy(x => x.Id).ToList();
            Result<Cardapio> result = new Result<Cardapio>(true, cardapios);
            return result;
        }

        public override Result<Cardapio> Read(Cardapio entity)
        {
            Cardapio item = context.Set<Cardapio>().
                Include(x => x.ItensCardapio).
                SingleOrDefault(c => c.Id == entity.Id);
            Result<Cardapio> result = new Result<Cardapio>(true, item);
            return result;
        }
    }
}
