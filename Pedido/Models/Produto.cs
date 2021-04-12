using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoAPI.Model
{
    [NotMapped]
    public class Produto : BaseType
    {
        public string NomeItem { get; set; }
        public decimal Valor { get; set; }
        public int CardapioId { get; set; }
        public string Observacao { get; set; }
    }
}
