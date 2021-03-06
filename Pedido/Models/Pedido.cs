using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoAPI.Model
{
    [Table("Pedido")]
    public class Pedido : BaseEntity
    {
        public List<ItemPedido> Itens { get; set; }
        public StatusPedido StatusPedido { get; set; }
        
        public int StatusPedidoId { get; set; }
        public Mesa Mesa { get; set; }
        [ForeignKey("Mesa")]
        public int MesaId { get; set; }

        public Pagamento Pagamento { get; set; }
    }
}
