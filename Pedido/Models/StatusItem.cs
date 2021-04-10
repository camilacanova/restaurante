using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoAPI.Model
{
    [Table("StatusItem")]
    public class StatusItem : BaseType
    {
        public string Descricao { get; set; }
    }
}