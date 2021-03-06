﻿using CardapioService.Data;
using CardapioService.Enum;
using CardapioService.Model;
using CardapioService.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Structures
{
    public class CardapioBuilder : AbstractBuilder<Cardapio>
    {
        public CardapioBuilder(CardapioServiceContext context) : base(context) { }

        public override BuilderResponse<Cardapio> create()
        {

            CardapioRepository cardapioRepo = new CardapioRepository(Context);
            Dictionary<EnumCommand, List<IStrategy<Cardapio>>> strategies = new Dictionary<EnumCommand, List<IStrategy<Cardapio>>>();

            var create = new List<IStrategy<Cardapio>>();
            create.Add(new CreateCardapio());

            var read = new List<IStrategy<Cardapio>>();
            var update = new List<IStrategy<Cardapio>>();
            var delete = new List<IStrategy<Cardapio>>();

            strategies.Add(EnumCommand.CREATE, create);
            strategies.Add(EnumCommand.READ, read);
            strategies.Add(EnumCommand.UPDATE, update);
            strategies.Add(EnumCommand.DELETE, delete);


            BuilderResponse<Cardapio> response = new BuilderResponse<Cardapio>();
            response.Repository = cardapioRepo;
            response.Strategies = strategies;

            return response;
        }
    }
}
