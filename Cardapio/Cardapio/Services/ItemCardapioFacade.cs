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
    public class ItemCardapioFacade : DefaultFacade<ItemCardapio>
    {
        public ItemCardapioFacade(IFactory<ItemCardapio> factory, CardapioServiceContext context) : base(new ItemCardapioFactory(context))
        {
        }
    }
}
