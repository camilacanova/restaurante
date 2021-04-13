using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteUI.Models
{
    [Table("StatusPedido")]
    public class StatusPedido : BaseEntity
    {
        public string Descricao { get; set; }
    }
}