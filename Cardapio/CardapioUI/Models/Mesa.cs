using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioUI.Models
{
    [Table("Mesa")]
    public class Mesa : BaseEntity
    {
        public int NumeroMesa { get; set; }

        public bool Ocupada {get;set;}
    }
}
