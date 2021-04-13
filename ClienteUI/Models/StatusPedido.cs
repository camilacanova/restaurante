using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteUI.Models
{
    [Table("StatusPedido")]
    public class StatusPedido : BaseType
    {
        public string Descricao { get; set; }
    }
}