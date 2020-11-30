using CardapioService.Data;
using CardapioService.Model;
using CardapioService.Structures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Services
{
    public class CardapioFacade : DefaultFacade<Cardapio>
    {
        public CardapioFacade(IFactory<Cardapio> factory, CardapioServiceContext context) : base(new CardapioFactory(context))
        {
        }
    }
}
