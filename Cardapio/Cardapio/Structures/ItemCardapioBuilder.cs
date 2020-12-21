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
    public class ItemCardapioBuilder : AbstractBuilder<ItemCardapio>
    {
        public ItemCardapioBuilder(CardapioServiceContext context) : base(context)
        {
        }

        public override BuilderResponse<ItemCardapio> create()
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


            BuilderResponse<ItemCardapio> response = new BuilderResponse<ItemCardapio>();
            response.Repository = cardapioRepo;
            response.Strategies = strategies;

            return response;
        }
    }
}
