using System.Collections.Generic;
using PedidoAPI.Model;
using PedidoAPI.Util;

namespace PedidoAPI.Strategies
{
    public interface IGetItemPedido : IStrategy<ItemPedido>
    {
    }
    public class GetItemPedido : IGetItemPedido
    {
        private IGetProdutoStrategy _getProdutoStrategy;
        public GetItemPedido(IGetProdutoStrategy getProdutoStrategy)
        {
            _getProdutoStrategy = getProdutoStrategy;
        }
        public Result<ItemPedido> execute(ItemPedido entity)
        {
            var result = _getProdutoStrategy.execute(new Produto() { Id = entity.ProdutoId, CardapioId = entity.CardapioId });
            if (result.Success)
            {
                entity.Produto = result.Entities[0];
                return new Result<ItemPedido>() { Entities = new List<ItemPedido>() { entity }, Success = true};
            }
            else
                return new Result<ItemPedido>() { Success = false, Messages = new List<string>() { "Erro ao consultar no serviço de Cardápio" } };

        }
    }
}