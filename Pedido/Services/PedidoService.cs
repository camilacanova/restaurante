using System;
using System.Collections.Generic;
using PedidoAPI.Data;
using PedidoAPI.Model;
using PedidoAPI.Util;

namespace PedidoAPI.Services
{
    public class PedidoService : IService<Pedido>
    {
        private IRepository<Pedido> repo;
        public PedidoService(IRepository<Pedido> repo)
        {
            this.repo = repo; 
        }

        public Result<Pedido> Create(Pedido entity)
        {
            return repo.Create(entity);
        }

        public Result<Pedido> Delete(Pedido entity)
        {
            throw new NotImplementedException();
        }

        public Result<Pedido> Read(Pedido entity)
        {
            return repo.ReadAll(entity);
        }

        public Result<Pedido> ReadAll(Pedido entity)
        {
            return repo.Read(entity);
        }

        public Result<Pedido> Update(Pedido entity)
        {
            return repo.Update(entity);
        }
    }
}
