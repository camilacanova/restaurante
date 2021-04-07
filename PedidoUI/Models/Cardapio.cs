using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoUI.Models
{
    [Table("Cardapio")]
    public class Cardapio : BaseEntity
    {
        public string Nome { get; set; }
    }
}
