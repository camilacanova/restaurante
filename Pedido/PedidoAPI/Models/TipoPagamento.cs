
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoAPI.Model
{
    [Table("TipoPagamento")]
    public class TipoPagamento : BaseEntity
    {
        public string Descricao { get; set; }
    }
}
