using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteUI.Models
{
    public class IncluiItemPedidoUnicoViewModel: IncluiItemPedidoViewModel
    {
        public string pedidoId { get; set; }
    }
}
