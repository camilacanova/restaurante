using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteUI.Models
{
    public class IncluiPedidoViewModel
    {
        public List<IncluiItemPedidoViewModel> Itens { get; set; }
        public int StatusPedidoId { get; set; }
        public int MesaId { get; set; }
    }
}
