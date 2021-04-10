using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoAPI.Model
{
    [Table("StatusPedido")]
    public class StatusPedido : BaseType
    {
        public string Descricao { get; set; }
    }
}