using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioUI.Models
{
    [Table("Restaurante")]
    public class Restaurante : BaseEntity
    {
        public string Nome { get; set; }
        public List<Cardapio> Cardapios { get; set; }
    }
}
