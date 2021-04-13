using System;
using System.Collections.Generic;
using PedidoAPI.Model;
using PedidoAPI.Util;

namespace PedidoAPI.Strategies
{
    public interface IPostItemPedido : IStrategy<ItemPedido>
    {
    }
    public class PostItemPedido : IPostItemPedido
    {
        public Result<ItemPedido> execute(ItemPedido entity)
        {
            var result = new Result<ItemPedido>();
            result.Entities = new List<ItemPedido>();
            result.Messages = new List<string>();
            result.Success = true;

            if (entity.Quantidade < 1)
            {
                result.Success = false;
                result.Messages.Add("É preciso adicionar a quantidade minima do item (1)");
            }

            int produtoId = entity.Produto == null ? entity.ProdutoId : entity.Produto.Id;
            if (entity.ProdutoId < 1)
            {
                result.Success = false;
                result.Messages.Add("É preciso adicionar um produto ao item");
            }

            entity.Ativo = true;
            entity.Id = new Guid();
            result.Entities[0] = entity;

            return result;
        }
    }
}
