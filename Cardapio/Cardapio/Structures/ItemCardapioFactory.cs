using CardapioService.Data;
using CardapioService.Enum;
using CardapioService.Model;
using CardapioService.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Structures
{
    public class ItemCardapioFactory : AbstractSimpleFactory<ItemCardapio>
    {
        public ItemCardapioFactory(CardapioServiceContext context) : base(context)
        {
        }

        public override FactoryResponse<ItemCardapio> create()
        {
            ItemCardapioRepository cardapioRepo = new ItemCardapioRepository(Context);
            Dictionary<EnumCommand, List<IStrategy<ItemCardapio>>> strategies = new Dictionary<EnumCommand, List<IStrategy<ItemCardapio>>>();

            var create = new List<IStrategy<ItemCardapio>>();
            create.Add(new CreateItemCardapio());

            var read = new List<IStrategy<ItemCardapio>>();
            var update = new List<IStrategy<ItemCardapio>>();
            var delete = new List<IStrategy<ItemCardapio>>();

            strategies.Add(EnumCommand.CREATE, create);
            strategies.Add(EnumCommand.READ, read);
            strategies.Add(EnumCommand.UPDATE, update);
            strategies.Add(EnumCommand.DELETE, delete);


            FactoryResponse<ItemCardapio> response = new FactoryResponse<ItemCardapio>();
            response.Repository = cardapioRepo;
            response.Strategies = strategies;

            return response;
        }
    }
}
