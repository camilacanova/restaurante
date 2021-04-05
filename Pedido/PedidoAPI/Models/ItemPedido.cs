using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoAPI.Model
{
    [Table("ItemPedido")]
    public class ItemPedido : BaseEntity
    {
        [NotMapped]
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public StatusItem Status { get; set; }
        public int StatusItemId { get; set; }
    }
}
