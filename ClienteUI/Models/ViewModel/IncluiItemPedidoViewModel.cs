using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteUI.Models
{
    public class IncluiItemPedidoViewModel
    {
        public int ProdutoId { get; set; }
        public int CardapioId { get; set; }
        public int Quantidade { get; set; }
        public int StatusItemId { get; set; }
    }
}
