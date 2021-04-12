using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PedidoAPI.Data;
using PedidoAPI.Model;
using PedidoAPI.Util;

namespace PedidoAPI.Data.Repositories
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
                int mesaId = entity.Mesa == null ? entity.MesaId : entity.Mesa.Id;
                Pedido item = context.Pedidos
                    .Include(x => x.Mesa)
                    .Include(x => x.StatusPedido)
                    .Include(x => x.Pagamento)
                    .Include(i => i.Itens)
                    .ThenInclude(x => x.StatusItem)
                    .Where(x => x.Id == entity.Id || (mesaId > 0 ? x.MesaId == mesaId : true)).FirstOrDefault();
                Result<Pedido> result = new Result<Pedido>(true, item);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override Result<Pedido> ReadAll(Pedido entity)
        {
            try
            {
                List<Pedido> itens = context.Pedidos
                    .Include(x => x.Mesa)
                    .Include(x => x.StatusPedido)
                    .Include(x => x.Pagamento)
                    .Include(i => i.Itens)
                    .ThenInclude(x => x.StatusItem)
                    .OrderBy(x => x.Id).ToList();
                Result<Pedido> result = new Result<Pedido>(true, itens);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
