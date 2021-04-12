using System;
using System.Collections.Generic;
using PedidoAPI.Data;
using PedidoAPI.Data.Repositories;
using PedidoAPI.Model;
using PedidoAPI.Strategies;
using PedidoAPI.Util;

namespace PedidoAPI.Services
{
    public class ItemPedidoService : IService<ItemPedido>
    {
        private AbstractRepository<ItemPedido> repo;
        private IGetItemPedido getItemPedido;
        private IPatchItemPedido patchItemPedido;
        private IPostItemPedido postItemPedido;

        public ItemPedidoService(AbstractRepository<ItemPedido> repo,
            IGetItemPedido _getItemPedido,
            IPatchItemPedido _patchItemPedido,
            IPostItemPedido _postItemPedido)
        {
            this.repo = repo;
            getItemPedido = _getItemPedido;
            patchItemPedido = _patchItemPedido;
            postItemPedido = _postItemPedido;
        }

        public Result<ItemPedido> Create(ItemPedido entity)
        {
            var result = postItemPedido.execute(entity);
            if (result.Success)
                return repo.Create(entity);
            else
                return result;
        }

        public Result<ItemPedido> Read(ItemPedido entity)
        {
            var result = repo.Read(entity);
            for (int i = 0; i < result.Entities.Count; i++)
            {
                var r = getItemPedido.execute(result.Entities[i]);
                if (r.Success)
                    result.Entities[i] = r.Entities[0];
            }
            return result;
        }

        public Result<ItemPedido> ReadAll(ItemPedido entity)
        {
            var result = repo.ReadAll(entity);
            for (int i = 0; i < result.Entities.Count; i++)
            {
                var r = getItemPedido.execute(result.Entities[i]);
                if (r.Success)
                    result.Entities[i] = r.Entities[0];
            }
            return result;
        }

        public Result<ItemPedido> Update(ItemPedido entity)
        {
            var result = patchItemPedido.execute(entity);
            if (result.Success)
                return repo.Update(entity);
            else
                return result;
        }
    }
}
