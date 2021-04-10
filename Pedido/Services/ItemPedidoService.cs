using System;
using System.Collections.Generic;
using PedidoAPI.Data;
using PedidoAPI.Model;
using PedidoAPI.Util;

namespace PedidoAPI.Services
{
    public class ItemPedidoService : IService<ItemPedido>
    {
        private IRepository<ItemPedido> repo;
        public ItemPedidoService(IRepository<ItemPedido> repo)
        {
            this.repo = repo; 
        }

        public Result<ItemPedido> Create(ItemPedido entity)
        {
            return repo.Create(entity);
        }

        public Result<ItemPedido> Read(ItemPedido entity)
        {
            return repo.ReadAll(entity);
        }

        public Result<ItemPedido> ReadAll(ItemPedido entity)
        {
            return repo.Read(entity);
        }

        public Result<ItemPedido> Update(ItemPedido entity)
        {
            return repo.Update(entity);
        }
    }
}
