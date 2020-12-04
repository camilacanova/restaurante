using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioUI.Models
{
    [Table("ItemCardapio")]
    public class ItemCardapio : BaseEntity
    {
        public string NomeItem { get; set; }
        //public List<Adicional> AdicionaisItem { get; set; }

        public decimal Valor { get; set; }

        public int CategoriaId { get; set; }
        //public Categoria CategoriaItem { get; set; }

        public int CardapioId { get; set; }
        public Cardapio Cardapio { get; set; }
    }
}