using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioUI.Models
{
    [Table("ItemPedido")]
    public class ItemPedido : BaseType
    {
        [NotMapped]
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public int CardapioId { get; set; }
        public int Quantidade { get; set; }

        public StatusItem StatusItem { get; set; }
        [ForeignKey("StatusItem")]
        public int StatusItemId { get; set; }

        public Guid PedidoId { get; set; }
        [ForeignKey("PedidoId")]
        public virtual Pedido Pedido { get; set; }
    }
}
