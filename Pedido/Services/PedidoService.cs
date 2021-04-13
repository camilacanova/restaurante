using System;
using System.Collections.Generic;
using PedidoAPI.Data;
using PedidoAPI.Data.Repositories;
using PedidoAPI.Model;
using PedidoAPI.Strategies;
using PedidoAPI.Util;

namespace PedidoAPI.Services
{
    public class PedidoService : IService<Pedido>
    {
        private AbstractRepository<Pedido> repo;
        private IGetItemPedido _getItemPedido;
        private IPatchPedido _patchPedido;
        private IPostPedido _postPedido;
        public PedidoService(AbstractRepository<Pedido> repo,
            IGetItemPedido getItemPedido,
            IPatchPedido patchPedido,
            IPostPedido postPedido)
        {
            this.repo = repo;
            _getItemPedido = getItemPedido;
            _patchPedido = patchPedido;
            _postPedido = postPedido;
        }

        public Result<Pedido> Create(Pedido entity)
        {
            var result = _postPedido.execute(entity);
            if (result.Success)
            {
                entity = result.Entities[0];
                return repo.Create(entity);
            }
            else
                return result;
        }

        public Result<Pedido> Read(Pedido entity)
        {
            var result = repo.Read(entity);
            for (int i = 0; i < result.Entities.Count ; i++)
            {
                for (int j = 0; j < result.Entities[i].Itens.Count; j++)
                {
                    var r = _getItemPedido.execute(result.Entities[i].Itens[j]);
                    if (r.Success)
                        result.Entities[i].Itens[j] = r.Entities[0];
                }
            }
            return result;
        }

        public Result<Pedido> ReadAll(Pedido entity)
        {
            var result = repo.ReadAll(entity);
            for (int i = 0; i < result.Entities.Count; i++)
            {
                for (int j = 0; j < result.Entities[i].Itens.Count; j++)
                {
                    var r = _getItemPedido.execute(result.Entities[i].Itens[j]);
                    if (r.Success)
                        result.Entities[i].Itens[j] = r.Entities[0];
                }
            }
            return result;
        }

        public Result<Pedido> Update(Pedido entity)
        {
            var result = _patchPedido.execute(entity);
            if (result.Success)
                return repo.Update(entity);
            else
                return result;
        }
    }
}
