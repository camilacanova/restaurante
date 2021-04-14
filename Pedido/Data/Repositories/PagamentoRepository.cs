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
    public class PagamentoRepository : AbstractRepository<Pagamento>
    {
        public PagamentoRepository(PedidoContext context) : base(context)
        {
        }

        public override Result<Pagamento> Read(Pagamento entity)
        {
            try
            {
                Pagamento item = context.Set<Pagamento>()
                    .Include(x => x.TipoPagamento)
                    .Where(x => x.Id == entity.Id).FirstOrDefault();
                Result<Pagamento> result = new Result<Pagamento>(true, item);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Result<Pagamento> ReadAll(Pagamento entity)
        {
            try
            {
                List<Pagamento> itens = context.Set<Pagamento>()
                    .Include(x => x.TipoPagamento)
                    .OrderBy(x => x.Id).ToList();
                Result<Pagamento> result = new Result<Pagamento>(true, itens);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Result<Pagamento> ReadWhere(Expression<Func<Pagamento, bool>> predicate)
        {
            try
            {
                List<Pagamento> itens = context.Pagamentos
                   .Include(x => x.TipoPagamento)
                    .Where(predicate).ToList();
                Result<Pagamento> result = new Result<Pagamento>(true, itens);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
