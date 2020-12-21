using CardapioService.Data;
using CardapioService.Model;
using CardapioService.Structures;
using CardapioService.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Services
{
    public interface ICardapioFacade : IFacade<Cardapio>
    {

        Result<Cardapio> Update(Cardapio entity);
    }
}
