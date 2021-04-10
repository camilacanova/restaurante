using System;
using System.Collections.Generic;
using System.Linq;
using PedidoAPI.Data;
using PedidoAPI.Model;
using PedidoAPI.Util;

namespace PedidoAPI.Data.Repositories
{
    public class ItemPedidoRepository : AbstractRepository<ItemPedido>
    {
        public ItemPedidoRepository(PedidoContext context) : base(context)
        {
        }

        public override Result<ItemPedido> Read(ItemPedido entity)
        {
            try
            {
                ItemPedido item = context.Set<ItemPedido>().Where(x=> x.Id == entity.Id).FirstOrDefault();
                Result<ItemPedido> result = new Result<ItemPedido>(true, item);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
