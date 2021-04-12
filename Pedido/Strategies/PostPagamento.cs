using System.Collections.Generic;
using PedidoAPI.Data;
using PedidoAPI.Model;
using PedidoAPI.Util;

namespace PedidoAPI.Strategies
{
    public interface IPostPagamento : IStrategy<Pagamento>
    {
    }
    public class PostPagamento : IPostPagamento
    {
        private AbstractRepository<Pedido> repo;
        public PostPagamento(AbstractRepository<Pedido> repo)
        {
            this.repo = repo;
        }
        public Result<Pagamento> execute(Pagamento entity)
        {
            var result = new Result<Pagamento>();
            result.Messages = new List<string>();
            result.Success = true;

            Pedido _pedido = repo.Read(new Pedido() { Id = entity.PedidoId }).Entities[0];

            decimal valorItens = 0;
            _pedido.Itens.ForEach(delegate (ItemPedido i)
            {
                valorItens += i.Produto.Valor * i.Quantidade;
            });
            
            if (entity.Valor != valorItens)
            {
                result.Success = false;
                result.Messages.Add("Valor do pagamento diferente dos itens do pedido");
            }

            return result;
        }
    }
}
