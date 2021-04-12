using System.Collections.Generic;
using PedidoAPI.Model;
using PedidoAPI.Model.Enums;
using PedidoAPI.Util;

namespace PedidoAPI.Strategies
{
    public interface IPatchPedido : IStrategy<Pedido>
    {
    }
    public class PatchPedido : IPatchPedido
    {
        public Result<Pedido> execute(Pedido entity)
        {
            var result = new Result<Pedido>();
            result.Messages = new List<string>();
            result.Success = true;

            int status = entity.StatusPedido == null ? entity.StatusPedidoId : entity.StatusPedido.Id;

            if (status == (int)EnumStatusPedido.Pago)
            {
                decimal valorItens = 0;
                entity.Itens.ForEach(delegate (ItemPedido i)
                {
                    valorItens += i.Produto.Valor * i.Quantidade;
                });
                
                if (entity.Pagamento == null)
                {
                    result.Success = false;
                    result.Messages.Add("É necessário vincular uma pagamento ao pedido");
                }
                else if (entity.Pagamento.Valor != valorItens)
                {
                    result.Success = false;
                    result.Messages.Add("Valor do pagamento diferente dos itens do pedido");
                }
            }

            return result;
        }
    }
}
