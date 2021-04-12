using System.Collections.Generic;
using PedidoAPI.Model;
using PedidoAPI.Model.Enums;
using PedidoAPI.Util;

namespace PedidoAPI.Strategies
{
    public interface IPatchItemPedido : IStrategy<ItemPedido>
    {
    }
    public class PatchItemPedido : IPatchItemPedido
    {
        public Result<ItemPedido> execute(ItemPedido entity)
        {
            var result = new Result<ItemPedido>();
            result.Messages = new List<string>();
            result.Success = true;

            if (entity.StatusItemId != (int)EnumStatusItem.Solicitado ||
                entity.StatusItem.Id != (int)EnumStatusItem.Solicitado)
            {
                result.Success = false;
                result.Messages.Add("Item já em preparação, não é possível alterar");
            }

            return result;
        }
    }
}
