using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PedidoAPI.Data;
using PedidoAPI.Model;
using PedidoAPI.Util;

namespace PedidoAPI.Data.Repositories
{
    public class MesaRepository : AbstractTypeRepository<Mesa>
    {
        public MesaRepository(PedidoContext context) : base(context)
        {
        }
    }
}
