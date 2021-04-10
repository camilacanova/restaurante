using System;
using System.Collections.Generic;
using PedidoAPI.Data;
using PedidoAPI.Model;
using PedidoAPI.Util;

namespace PedidoAPI.Services
{
    public class PagamentoService : IService<Pagamento>
    {
        private IRepository<Pagamento> repo;
        public PagamentoService(IRepository<Pagamento> repo)
        {
            this.repo = repo; 
        }

        public Result<Pagamento> Create(Pagamento entity)
        {
            return repo.Create(entity);
        }

        public Result<Pagamento> Read(Pagamento entity)
        {
            return repo.ReadAll(entity);
        }

        public Result<Pagamento> ReadAll(Pagamento entity)
        {
            return repo.Read(entity);
        }

        public Result<Pagamento> Update(Pagamento entity)
        {
            return repo.Update(entity);
        }
    }
}
