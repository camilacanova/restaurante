using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteUI.Models
{
    [Table("Mesa")]
    public class Mesa : BaseType
    {
        public int NumeroMesa { get; set; }

        public bool Ocupada {get;set;}
    }
}
