using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioUI.Models
{
    [Table("StatusPedido")]
    public class StatusPedido : BaseEntity
    {
        public string Descricao { get; set; }
    }
}