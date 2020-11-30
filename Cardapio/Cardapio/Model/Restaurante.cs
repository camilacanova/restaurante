using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CardapioService.Model
{
    [Table("Restaurante")]
    public class Restaurante : BaseEntity
    {
        public string Nome { get; set; }
        public Cardapio Cardapio { get; set; }
    }
}
