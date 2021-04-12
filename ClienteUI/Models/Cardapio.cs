using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteUI.Models
{
    [Table("Cardapio")]
    public class Cardapio : BaseEntity
    {
        public string Nome { get; set; }
        public string Imagem { get; set; }
    }
}
