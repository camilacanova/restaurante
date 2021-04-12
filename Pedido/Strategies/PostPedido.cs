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
            result.Messages = new List<string>();
            result.Success = true;

            if (entity.Mesa == null && entity.MesaId <= 0)
            {
                result.Success = false;
                result.Messages.Add("É necessário vincular uma Mesa ao pedido");
            }

            return result;
        }
    }
}
