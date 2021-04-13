using System;
using System.Collections.Generic;
using PedidoAPI.Model;
using PedidoAPI.Util;

namespace PedidoAPI.Strategies
{
    public interface IPostPedido : IStrategy<Pedido>
    {
    }
    public class PostPedido : IPostPedido
    {
        public Result<Pedido> execute(Pedido entity)
        {
            var result = new Result<Pedido>();
            result.Entities = new List<Pedido>();
            result.Messages = new List<string>();
            result.Success = true;

            if (entity.Mesa == null && entity.MesaId <= 0)
            {
                result.Success = false;
                result.Messages.Add("É necessário vincular uma Mesa ao pedido");
            }

            for (int i = 0; i < entity.Itens.Count; i++)
            {
                entity.Itens[i].Id = new Guid();
                entity.Itens[i].Ativo = true;
            }

            entity.Id = new Guid();
            entity.Ativo = true;
            result.Entities[0] = entity;

            return result;
        }
    }
}
