using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioUI.Models
{
    [Table("Cardapio")]
    public class Cardapio : BaseEntity
    {
        public string Nome { get; set; }
        public List<ItemCardapio> ItensCardapio { get; set; }

        public int RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }
    }
}
