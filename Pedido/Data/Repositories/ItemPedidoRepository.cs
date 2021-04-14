using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
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
                ItemPedido item = context.Set<ItemPedido>()
                    .Include(x => x.StatusItem)
                    .Where(x => x.Id == entity.Id).FirstOrDefault();
                Result<ItemPedido> result = new Result<ItemPedido>(true, item);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override Result<ItemPedido> ReadAll(ItemPedido entity)
        {
            try
            {
                List<ItemPedido> itens = context.Set<ItemPedido>()
                    .Include(x => x.StatusItem)
                    .OrderBy(x => x.Id).ToList();
                Result<ItemPedido> result = new Result<ItemPedido>(true, itens);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override Result<ItemPedido> ReadWhere(Expression<Func<ItemPedido, bool>> predicate)
        {
            try
            {
                List<ItemPedido> itens = context.ItensPedido
                    .Include(x => x.StatusItem)
                    .Where(predicate).ToList();
                Result<ItemPedido> result = new Result<ItemPedido>(true, itens);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
