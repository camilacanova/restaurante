using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioService.Model
{
    [Table("Cardapio")]
    public class Cardapio : BaseEntity
    {
        public string Nome { get; set; }
        ////public List<ItemCardapio> ItensCardapio { get; set; }
        public string Observacao { get; set; }
    }
}
