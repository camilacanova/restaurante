using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioUI.Models
{
    [Table("StatusItem")]
    public class StatusItem : BaseEntity
    {
        public string Descricao { get; set; }
    }
}