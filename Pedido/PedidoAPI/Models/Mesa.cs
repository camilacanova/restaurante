using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoAPI.Model
{
    [Table("Mesa")]
    public class Mesa : BaseEntity
    {
        public int NumeroMesa { get; set; }
    }
}
