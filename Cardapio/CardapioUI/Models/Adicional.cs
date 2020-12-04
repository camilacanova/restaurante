using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioUI.Models
{

    [Table("Adicional")]
    public class Adicional : BaseEntity
    {
        public string Nome { get; set; }
        public List<TipoAdicional> TiposAdicionais { get; set; }

        public int ItemCardapioId { get; set; }
        public ItemCardapio ItemCardapio { get; set; }
    }
}