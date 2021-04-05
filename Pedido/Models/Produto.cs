using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoAPI.Model
{
    [NotMapped]
    public class Produto : BaseEntity
    {
        public String Nome { get; set; }
        public Decimal Preco { get; set; }
    }
}
