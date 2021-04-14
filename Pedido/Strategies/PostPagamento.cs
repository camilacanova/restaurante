using System;
using System.Collections.Generic;
using PedidoAPI.Data;
using PedidoAPI.Model;
using PedidoAPI.Model.Enums;
using PedidoAPI.Util;

namespace PedidoAPI.Strategies
{
    public interface IPostPagamento : IStrategy<Pagamento>
    {
    }
    public class PostPagamento : IPostPagamento
    {
        private AbstractRepository<Pedido> repoPedido;
        private AbstractTypeRepository<Mesa> repoMesa;
        public PostPagamento(AbstractRepository<Pedido> repoPedido, AbstractTypeRepository<Mesa> repoMesa)
        {
            this.repoPedido = repoPedido;
            this.repoMesa = repoMesa;
        }
        public Result<Pagamento> execute(Pagamento entity)
        {
            var result = new Result<Pagamento>();
            result.Entities = new List<Pagamento>();
            result.Messages = new List<string>();
            result.Success = true;

            Pedido _pedido = repoPedido.ReadWhere(x => x.Id == entity.PedidoId).Entities[0];
            GetProdutoStrategy strategy = new GetProdutoStrategy();

            decimal valorItens = 0;
            _pedido.Itens.ForEach(delegate (ItemPedido i)
            {
                Produto prod = strategy.execute(new Produto() { CardapioId = i.CardapioId, Id = i.ProdutoId }).Entities[0];

                valorItens += prod.Valor * i.Quantidade;
            });

            ////validação de status dos itens de pedido
            // foreach (ItemPedido item in _pedido.Itens)
            // {
            //     if (item.StatusItemId != (int)EnumStatusItem.Entregue)
            //     {
            //         result.Success = false;
            //         result.Messages.Add("Valor do pagamento diferente dos itens do pedido");
            //         break;
            //     }
            // }

            if (entity.Valor != valorItens)
            {
                result.Success = false;
                result.Messages.Add("Valor do pagamento diferente dos itens do pedido");
            }

            //atualizar mesa
            var Mesa = _pedido.Mesa;
            Mesa.Ocupada = false;
            repoMesa.Update(Mesa);

            //Encerra pedido
            _pedido.StatusPedidoId = (int)EnumStatusPedido.Pago;
            repoPedido.Update(_pedido);


            entity.Id = new Guid();
            entity.Ativo = true;
            result.Entities.Add(entity);

            return result;
        }
    }
}
