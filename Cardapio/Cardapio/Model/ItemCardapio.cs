using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioService.Model
{
    [Table("ItemCardapio")]
    public class ItemCardapio : BaseEntity
    {
        public string NomeItem { get; set; }
        public List<Adicional> AdicionaisItem { get; set; }
        public Categoria CategoriaItem { get; set; }
    }
}