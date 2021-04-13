using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteUI.Models
{
    [Table("Pagamento")]
    public class Pagamento : BaseEntity
    {
        public decimal Valor { get; set; }
        public int Parcelas { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        [ForeignKey("TipoPagamento")]
        public int TipoPagamentoId { get; set; }

        public Pedido Pedido { get; set; }

        [ForeignKey("Pedido")]
        public Guid PedidoId { get; set; }
    }
}
