using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioUI.Models
{
    [NotMapped]
    public class Produto : BaseEntity
    {
        public string NomeItem { get; set; }
        public decimal Valor { get; set; }
        public int CardapioId { get; set; }
    }
}
