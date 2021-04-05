using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoAPI.Model
{
    [Table("Pagamento")]
    public class Pagamento : BaseEntity
    {
        public decimal Valor { get; set; }
        public int Parcelas { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public int TipoPagamentoId { get; set; }

    }
}
