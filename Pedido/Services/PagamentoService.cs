using System;
using System.Collections.Generic;
using PedidoAPI.Data;
using PedidoAPI.Data.Repositories;
using PedidoAPI.Model;
using PedidoAPI.Strategies;
using PedidoAPI.Util;

namespace PedidoAPI.Services
{
    public class PagamentoService : IService<Pagamento>
    {
        private IPostPagamento _postPagamento;
        private AbstractRepository<Pagamento> repo;
        public PagamentoService(AbstractRepository<Pagamento> repo,
            IPostPagamento postPagamento)
        {
            this.repo = repo;
            _postPagamento = postPagamento;
        }

        public Result<Pagamento> Create(Pagamento entity)
        {
            var result = _postPagamento.execute(entity);
            if (result.Success)
            {
                entity = result.Entities[0];
                return repo.Create(entity);
            }
            else
                return result;
        }

        public Result<Pagamento> Read(Pagamento entity)
        {
            return repo.Read(entity);
        }

        public Result<Pagamento> ReadAll(Pagamento entity)
        {
            return repo.ReadAll(entity);
        }

        public Result<Pagamento> Update(Pagamento entity)
        {
            return repo.Update(entity);
        }
    }
}
