using System;
using System.Collections.Generic;
using System.Linq;
using PedidoAPI.Data;
using PedidoAPI.Model;
using PedidoAPI.Util;

namespace PedidoAPI.Data.Repositories
{
    public class PagamentoRepository : AbstractRepository<Pagamento>
    {
        public PagamentoRepository(PedidoContext context) : base(context)
        {
        }

        public override Result<Pagamento> Read(Pagamento entity)
        {
            try
            {
                Pagamento item = context.Set<Pagamento>().Where(x=> x.Id == entity.Id).FirstOrDefault();
                Result<Pagamento> result = new Result<Pagamento>(true, item);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
