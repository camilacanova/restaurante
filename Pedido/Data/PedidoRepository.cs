using System;
using System.Collections.Generic;
using System.Linq;
using PedidoAPI.Data;
using PedidoAPI.Model;
using PedidoAPI.Util;

namespace PedidoAPI.Data
{
    public class PedidoRepository : AbstractRepository<Pedido>
    {
        public PedidoRepository(PedidoContext context) : base(context)
        {
        }

        public override Result<Pedido> Read(Pedido entity)
        {
            try
            {
                Pedido item = context.Set<Pedido>().Where(x=> x.Id == entity.Id).FirstOrDefault();
                Result<Pedido> result = new Result<Pedido>(true, item);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
