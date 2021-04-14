using System;
using System.Collections.Generic;
using PedidoAPI.Data;
using PedidoAPI.Model;
using PedidoAPI.Model.Enums;
using PedidoAPI.Util;

namespace PedidoAPI.Strategies
{
    public interface IPostPedido : IStrategy<Pedido>
    {
    }
    public class PostPedido : IPostPedido
    {
        private AbstractRepository<Pedido> repoPedido;
        public PostPedido(AbstractRepository<Pedido> repoPedido)
        {
            this.repoPedido = repoPedido;
        }
        public Result<Pedido> execute(Pedido entity)
        {
            var result = new Result<Pedido>();
            result.Entities = new List<Pedido>();
            result.Messages = new List<string>();
            result.Success = true;

            var mesas = repoPedido.ReadWhere(x => x.StatusPedidoId != (int)EnumStatusPedido.Pago);

            if (mesas.Entities.Count > 0)
            {
                result.Success = false;
                result.Messages.Add("Já existe um pedido aberto para essa mesa");
                return result;
            }

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
            result.Entities.Add(entity);

            return result;
        }
    }
}
